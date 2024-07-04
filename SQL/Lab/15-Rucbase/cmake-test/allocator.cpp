#include <iostream>
#include <unordered_map>
#include <memory>
#include <cstring>

// 自定义分配器
template<typename T>
class CustomAllocator {
public:
    using value_type = T;

    // 指定的存储位置
    CustomAllocator(char *storage, size_t &offset): storage_(storage), offset_(offset) {}

    template <typename U>
    CustomAllocator(const CustomAllocator<U> &other) noexcept
        : storage_(other.storage_), offset_(other.offset_) {
    }

    T *allocate(std::size_t n) {
        T *ptr = reinterpret_cast<T *>(storage_ + offset_);
        offset_ += n * sizeof(T);
        return ptr;
    }

    void deallocate(T *p, std::size_t n) {
        // do nothing
    }

private:
    char *storage_;
    size_t &offset_;

    template <typename U> friend class CustomAllocator;
};

template <typename T, typename U>
bool operator==(const CustomAllocator<T> &, const CustomAllocator<U> &) { return true; }

template <typename T, typename U>
bool operator!=(const CustomAllocator<T> &, const CustomAllocator<U> &) { return false; }

int main() {
    const size_t mapSize = 3;
    const size_t keyBufferSize = mapSize * sizeof(int);
    const size_t valueBufferSize = mapSize * sizeof(char);

    // 分配用于存储键和值的内存
    char *keysBuffer = static_cast<char *>(std::malloc(keyBufferSize));
    char *valuesBuffer = static_cast<char *>(std::malloc(valueBufferSize));

    // 创建用于键和值的自定义分配器
    size_t keyOffset = 0;
    size_t valueOffset = 0;
    CustomAllocator<std::pair<const int, char>> alloc(keysBuffer, keyOffset);

    // 使用自定义分配器创建unordered_map
    std::unordered_map<int, char, std::hash<int>, std::equal_to<int>, CustomAllocator<std::pair<const int, char>>> map(10, std::hash<int>(), std::equal_to<int>(), alloc);

    // 插入元素
    map[1] = '1';
    map[2] = '2';
    map[3] = '3';

    // 使用自定义分配器的偏移量分配值
    CustomAllocator<char> valueAlloc(valuesBuffer, valueOffset);

    // 打印键和值以验证
    for (size_t i = 0; i < mapSize; ++i) {
        int key;
        char value;
        std::memcpy(&key, keysBuffer + i * sizeof(int), sizeof(int));
        std::memcpy(&value, valuesBuffer + i * sizeof(char), sizeof(char));
        std::cout << "Key: " << key << ", Value: " << value << std::endl;
    }

    // 释放内存
    std::free(keysBuffer);
    std::free(valuesBuffer);

    return 0;
}
