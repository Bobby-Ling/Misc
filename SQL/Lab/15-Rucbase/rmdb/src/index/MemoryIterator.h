#pragma once

/**
 * @author Bobby-Ling
 * @brief 为内存中自定义数据结构提供迭代器支持, 满足Data[size], sizeof(Data)==element_size
 * @note 保证迭代器不会超过尾后即end(); 迭代器支持随机存取; index_一直会变, 只是存取时加入越界判断逻辑
 */
template<
    typename PointerType = char *,
    typename ElementType = const char *
>
class MemoryIterator: public std::iterator<std::random_access_iterator_tag, char *> {
public:
    // using iterator_category = std::random_access_iterator_tag;
    using value_type = ElementType;
    using difference_type = std::ptrdiff_t;
    using pointer_type = PointerType;
    using dereference_type = ElementType;

    MemoryIterator(pointer_type mem, std::size_t element_size, std::size_t size = 0, std::size_t index = 0)
        : begin_ptr(mem), element_size_(element_size), size_(size), index_(index) {
    }

    /**
     * @brief 将指针转换至TargetType类型
     * @tparam TargetType
     * @return static_cast后的当前指针
     */
    template <typename TargetType>
    TargetType As() const {
        static_assert(std::is_convertible<pointer_type, TargetType>::value, "Invalid type conversion");
        return static_cast<TargetType>(begin_ptr + element_size_ * index_);
    }

    /**
     * @brief 解引用操作符
     */
    dereference_type operator*() const {
        return reinterpret_cast<ElementType>(begin_ptr + element_size_ * index_);
    }
    /**
     * @brief 指针访问操作符
     * @return 原始指针
     */
    pointer_type operator->() const {
        return begin_ptr + element_size_ * index_;
    }
    /**
     * @brief 下标访问操作符
     * @return 可以解释为特定数据类型value_type
     */
    value_type operator[](int n) {
        return reinterpret_cast<ElementType>(begin_ptr + element_size_ * n);
    }
    /**
     * @brief 前置++操作符
     */
    MemoryIterator &operator++() {
        ++index_;
        return *this;
    }
    /**
     * @brief 前置--操作符
     */
    MemoryIterator &operator--() {
        --index_;
        return *this;
    }
    /**
     * @brief 后置++操作符
     */
    MemoryIterator operator++(int) {
        MemoryIterator temp = *this;
        index_++;
        return temp;
    }
    /**
     * @brief 后置--操作符
     */
    MemoryIterator operator--(int) {
        MemoryIterator temp = *this;
        index_--;
        return temp;
    }
    MemoryIterator operator+(int n) {
        return MemoryIterator(begin_ptr, element_size_, size_, index_ + n);
    }
    MemoryIterator operator-(int n) {
        return MemoryIterator(begin_ptr, element_size_, size_, index_ - n);
    }
    MemoryIterator &operator+=(int n) {
        index_ += n;
        return * this;
    }
    MemoryIterator &operator-=(int n) {
        index_ -= n;
        return * this;
    }
    /**
     * @param other
     * @note 这里假定比较的都是同一内存实例的迭代器
     */
    bool operator==(const MemoryIterator &other) const { return index_ == other.index_; }
    bool operator!=(const MemoryIterator &other) const { return index_ != other.index_; }
    bool operator<(const MemoryIterator &other) const { return index_ < other.index_; }
    bool operator<=(const MemoryIterator &other) const { return index_ <= other.index_; }
    bool operator>(const MemoryIterator &other) const { return index_ > other.index_; }
    bool operator>=(const MemoryIterator &other) const { return index_ >= other.index_; }
    /**
     * @param other
     * @note 供std::distance使用; 不会>end()
     */
    difference_type operator-(const MemoryIterator &other) const {
        return index_ - other.index_;
    }
    MemoryIterator begin() {
        return MemoryIterator(begin_ptr, element_size_, size_, 0);
    }
    MemoryIterator end() {
        return MemoryIterator(begin_ptr, element_size_, size_, size_);
    }
    std::size_t GetSize() const { return size_; }
    std::size_t GetElementSize() const { return element_size_; }
    std::size_t GetIndex() const { return index_; }
private:
    pointer_type begin_ptr;
    std::size_t element_size_;
    std::size_t size_;
    std::size_t index_;
};