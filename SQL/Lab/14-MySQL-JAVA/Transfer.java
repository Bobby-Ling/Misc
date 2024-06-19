import java.sql.*;
import java.util.Scanner;

public class Transfer {
    static final String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://127.0.0.1:3306/finance?allowPublicKeyRetrieval=true&useUnicode=true&characterEncoding=UTF8&useSSL=false&serverTimezone=UTC";
    static final String USER = "root";
    static final String PASS = "123123";
    /**
     * 转账操作
     *
     * @param connection 数据库连接对象
     * @param sourceCard 转出账号
     * @param destCard 转入账号
     * @param amount  转账金额
     * @return boolean
     *   true  - 转账成功
     *   false - 转账失败
     */
    public static boolean transferBalance(Connection connection,
                                          String sourceCard,
                                          String destCard,
                                          double amount){
        try {
            connection.setAutoCommit(false);
            connection
                    .setTransactionIsolation(Connection.TRANSACTION_READ_COMMITTED);
            String sql = "SELECT\n" +
                    "    (\n" +
                    "        (\n" +
                    "            SELECT\n" +
                    "                COUNT(DISTINCT b_number)\n" +
                    "            FROM bank_card\n" +
                    "            WHERE b_number = ? OR b_number = ? ) = 2 AND\n" +
                    "            (\n" +
                    "                SELECT DISTINCT b_type\n" +
                    "                FROM bank_card\n" +
                    "                WHERE b_number = ? ) = '储蓄卡' AND\n" +
                    "            (\n" +
                    "                SELECT b_balance\n" +
                    "                FROM bank_card\n" +
                    "                WHERE b_number = ? ) >= ?)";
            PreparedStatement stmt = connection.prepareStatement(sql);
            stmt.setString(1, sourceCard);
            stmt.setString(2, destCard);
            stmt.setString(3, sourceCard);
            stmt.setString(4, sourceCard);
            stmt.setDouble(5, amount);
            ResultSet rs = stmt.executeQuery();
            if (rs.next()) {
                if (rs.getBoolean(1)) {
                    stmt.close();
                    sql = "UPDATE bank_card SET b_balance = b_balance + IF(b_type = '信用卡', ?, ?) WHERE b_number = ?";
                    stmt = connection.prepareStatement(sql);
                    // 转出, 不可能是信用卡
                    stmt.setDouble(1, -amount);
                    stmt.setDouble(2, -amount);
                    stmt.setString(3, sourceCard);
                    int retVal1 = stmt.executeUpdate();
                    // 转入, 信用卡取负
                    stmt.setDouble(1, -amount);
                    stmt.setDouble(2, amount);
                    stmt.setString(3, destCard);
                    int retVal2 = stmt.executeUpdate();
                    if ( retVal1 == 1 && retVal2 == 1 ){
                        connection.commit();
                        stmt.close();
                        return true;
                    }else{
                        connection.rollback();
                        stmt.close();
                        return false;
                    }
                }else {
                    return false;
                }
            }
            return false;
        } catch (SQLException e) {
            return false;
        }
    }

    // 不要修改main()
    public static void main(String[] args) throws Exception {

        Scanner sc = new Scanner(System.in);
        Class.forName(JDBC_DRIVER);

        Connection connection = DriverManager.getConnection(DB_URL, USER, PASS);

        while(sc.hasNext())
        {
            String input = sc.nextLine();
            if(input.equals(""))
                break;

            String[]commands = input.split(" ");
            if(commands.length ==0)
                break;
            String payerCard = commands[0];
            String  payeeCard = commands[1];
            double  amount = Double.parseDouble(commands[2]);
            if (transferBalance(connection, payerCard, payeeCard, amount)) {
                System.out.println("转账成功。" );
            } else {
                System.out.println("转账失败,请核对卡号，卡类型及卡余额!");
            }
        }
    }

}
