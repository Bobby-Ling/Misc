package homework.ch11_13.p4;

import javax.swing.text.rtf.RTFEditorKit;
import java.util.ArrayList;
import java.util.List;

/**
 * 复合迭代器, 用于复合组件的迭代
 */
public class CompositeIterator implements ComponentIterator {
    /**
     * 保存遍历到的每个节点的迭代器的列表
     */
    protected List<ComponentIterator> iterators = new ArrayList<ComponentIterator>();

    /**
     * @param iterator 要迭代的组件树(CompositeComponent)的根节点的迭代器
     */
    public CompositeIterator(ComponentIterator iterator) {
        this.iterators.add(iterator);
    }

    @Override
    public boolean hasNext() {
        if (iterators.isEmpty()) return false;
        if (iterators.get(0).hasNext()) {
            return true;
        } else {
            iterators.remove(0);
            return hasNext();
        }
    }

    @Override
    public Component next() {
        if (this.hasNext()) {
            Component component = iterators.get(0).next();
            if (component instanceof CompositeComponent compositeComponent) {
                iterators.add(compositeComponent.children.createIterator());
            }
            return component;
        } else
            return null;
    }
}
