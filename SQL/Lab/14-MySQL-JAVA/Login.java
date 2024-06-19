import java.sql.*;
import java.util.Scanner;

public class Login {
    public static void main(String[] args) {
        Connection connection = null;
        //申明下文中的resultSet, statement
        PreparedStatement statement = null;
        ResultSet resultSet = null;


        Scanner input = new Scanner(System.in);

        System.out.print("请输入用户名：");
        String loginName = input.nextLine();
        System.out.print("请输入密码：");
        String loginPass = input.nextLine();

        try {
            Class.forName("com.mysql.cj.jdbc.Driver");

            String userName = "root";
            String passWord = "123123";
            String url = "jdbc:mysql://127.0.0.1:3306/finance?useUnicode=true&characterEncoding=UTF8&useSSL=false&serverTimezone=UTC";
            connection = DriverManager.getConnection(url, userName, passWord);
            // 补充实现代码:

            String sql = "SELECT IF(EXISTS(SELECT * FROM client WHERE c_mail = ? AND c_password = ?),1,0) AS has_user";
            statement = connection.prepareStatement(sql);
            statement.setString(1, loginName);
            statement.setString(2, loginPass);
            resultSet = statement.executeQuery();
            if(resultSet.next()) {
                if(resultSet.getBoolean("has_user")){
                    System.out.println("登录成功。");
                }else {
                    System.out.println("用户名或密码错误！");
                }
            }


        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        } finally {
            try {
                if (resultSet != null) {
                    resultSet.close();
                }
                if (statement != null) {
                    statement.close();
                }

                if (connection != null) {
                    connection.close();
                }
            } catch (SQLException throwables) {
                throwables.printStackTrace();
            }
        }
    }
}

/*
测试用例1：
请输入用户名：8443517887@qq.com
请输入密码：1ONk7ghHXHgjx
登录成功。
测试用例2：
请输入用户名：404312032@126.com
请输入密码：1ONk7ghHXHgjx
用户名或密码错误！
测试用例3：
请输入用户名：8443517887@qq.com
请输入密码：' or '1'='1
用户名或密码错误！
测试用例4：
请输入用户名：whoever
请输入密码：' or '1'='1
用户名或密码错误！
 */