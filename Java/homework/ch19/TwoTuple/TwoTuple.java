package TwoTuple;

public class TwoTuple<T1 extends Comparable<T1>,T2 extends Comparable<T2>>
        implements Comparable<TwoTuple<T1,T2>> {
    private T1 first;
    private T2 second;

    public TwoTuple(T1 first, T2 second) {
        this.first = first;
        this.second = second;
    }

    @Override
    public int compareTo(TwoTuple<T1,T2> o) {
        if(this.first.compareTo(o.first)!=0){
            return this.first.compareTo(o.first);
        }else{
            return this.second.compareTo(o.second);
        }
    }

    @Override
    public String toString() {
        return "(" + first + "," + second + ")";
    }

    @Override
    public boolean equals(Object obj) {
        if (obj instanceof TwoTuple anotherTwoTuple) {
            if(this==anotherTwoTuple) return true;
            return this.first.equals(anotherTwoTuple.first)&&
                    this.second.equals(anotherTwoTuple.second);
        }
        return false;
    }

    public T1 getFirst() {
        return first;
    }

    public void setFirst(T1 first) {
        this.first = first;
    }

    public T2 getSecond() {
        return second;
    }

    public void setSecond(T2 second) {
        this.second = second;
    }
}
