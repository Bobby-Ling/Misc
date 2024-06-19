import java.sql.*;
import java.util.Scanner;

public class RemoveCard {
    static final String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://127.0.0.1:3306/finance?allowPublicKeyRetrieval=true&useUnicode=true&characterEncoding=UTF8&useSSL=false&serverTimezone=UTC";
    static final String USER = "root";
    static final String PASS = "123123";
    /**
     * 删除bank_card表中数据
     *
     * @param connection 数据库连接对象
     * @param b_c_id 客户编号
     * @param b_number 银行卡号
     */
    public static int removeBankCard(Connection connection,
                                     int b_c_id, String b_number){
        PreparedStatement stmt = null;
        try {
            String sql = "DELETE FROM bank_card WHERE b_c_id = ? AND b_number = ?;";
            stmt = connection.prepareStatement(sql);
            stmt.setInt(1, b_c_id);
            stmt.setString(2, b_number);
            /*
            executeUpdate()返回值:
            (1) the `row count` for SQL Data Manipulation Language (DML) statements (INSERT, UPDATE or DELETE)
            (2) `0` for SQL statements that return nothing
            当前insert为DML语句, 因此直接返回即可
            */
            return stmt.executeUpdate();
        } catch (SQLException e) {
            return 0;
        } finally {
            try {
                if (stmt != null) {
                    stmt.close();
                }
                if (connection != null) {
                    connection.close();
                }
            } catch (SQLException throwables) {
                throwables.printStackTrace();
            }
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
            int id = Integer.parseInt(commands[0]);
            String carNumber = commands[1];

            int n = removeBankCard(connection, id, carNumber);
            if (n > 0) {
                System.out.println("已销卡数：" + n);
            } else {
                System.out.println("销户失败，请检查客户编号或银行卡号！" );
            }
        }
    }

}
