public class Fan {
    public final static int SLOW = 1, MEDIUM = 2, FAST = 3;
    private boolean on = false;
    private int speed = SLOW;
    private String color = "blue";
    private double radius = 5;

    public Fan() {

    }
    public Fan(boolean on, int speed, String color, double radius) {
        this.on = on;
        this.speed = speed;
        this.color = color;
        this.radius = radius;
    }
    
    public boolean isOn() {
        return on;
    }
    public int getSpeed() {
        return speed;
    }
    public String getColor() {
        return color;
    }
    public double getRadius() {
        return radius;
    }

    public void setOn(boolean on) {
        this.on = on;
    }
    public void setSpeed(int speed) {
        this.speed = speed;
    }
    public void setColor(String color) {
        this.color = color;
    }
    public void setRadius(double radius) {
        this.radius = radius;
    }
    @Override
    public String toString() {
        if (on) {
            return new String("speed:"+speed + " color:" + color + " radius:" + radius + " ");
        } else {
            return new String("fan is off" + " color:" + color + " radius:" + radius + " ");
        }
    }
}
/**
 * test
 */
class test {
    public static void main(String[] args) {
        Fan f1=new Fan(true,Fan.SLOW,"yellow",10), f2=new Fan(false,Fan.MEDIUM,"blue",5);
        System.out.println(f1.toString());
        System.out.println(f2.toString());
    }
    
}