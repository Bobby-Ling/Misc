import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class Transform {
    static final String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
    static final String DB_URL = "jdbc:mysql://127.0.0.1:3306/sparsedb?allowPublicKeyRetrieval=true&useUnicode=true&characterEncoding=UTF8&useSSL=false&serverTimezone=UTC";
    static final String USER = "root";
    static final String PASS = "123123";
    static final String TABLE_NAME = "entrance_exam";
    static final String SC_TABLE_NAME = "sc";

    /**
     * 向sc表中插入数据
     *
     */
    public static int insertSC(PreparedStatement stmt, int sno, String col_name, String col_value) throws SQLException {
        stmt.setInt(1, sno);
        stmt.setString(2, col_name);
        stmt.setString(3, col_value);
        return stmt.executeUpdate();
    }

    public static void main(String[] args) throws Exception {
        Class.forName(JDBC_DRIVER);
        Connection conn = DriverManager.getConnection(DB_URL, USER, PASS);
        // 获取数据库元数据
        DatabaseMetaData metaData = conn.getMetaData();
        // 获取列信息
        ResultSet rsTableColumnNames = metaData.getColumns(null, null, TABLE_NAME, null);
        // 遍历结果集并获取列名
        List<String> columnNames = new ArrayList<String>();
        while (rsTableColumnNames.next()) {
            columnNames.add(rsTableColumnNames.getString("COLUMN_NAME"));
        }
        String insertSql = "insert into " + SC_TABLE_NAME + " values(?,?,?)";
        PreparedStatement insertStmt = conn.prepareStatement(insertSql);

        String sql = "SELECT * FROM entrance_exam";
        Statement stmt = conn.createStatement();
        ResultSet rs = stmt.executeQuery(sql);
        while(rs.next()){
            int sno = rs.getInt("sno");
            for (int i = 1; i < columnNames.size(); i++) {
                String col_name = columnNames.get(i);
                int col_value = rs.getInt(col_name);
                if (col_value != 0) {
                    insertSC(insertStmt, sno, col_name, Integer.toString(col_value));
                }
            }
        }
        stmt.close();
        insertStmt.close();
        conn.close();
    }
}