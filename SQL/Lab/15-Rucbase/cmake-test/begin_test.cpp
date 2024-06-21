#include <stdio.h>
// #include <ranges>
#include <vector>
#include <iterator> 
#include <memory>
#include <iostream>
#include <cstdint>
#include <algorithm>
#include <numeric>
#include <chrono>

#include "MemoryIterator.h"

using namespace std;




int main(int, char **) {

    // begin本来只能绑定至数组, 无法绑定至任意内存
    // 但是迭代器访问次数可以任意指定
    char arr[10] = "123456789";
    auto arr_begin = std::begin(arr);
    auto arr_end = std::end(arr) + 10;
    int i = 0;
    for (auto it = arr_begin;it != arr_end;it++) {
        // cout << i;
        // cout << *it << it;
        cout << reinterpret_cast<uintptr_t>(it) << " " << reinterpret_cast<ulong>(arr + i++) << endl;
    }

    cout << endl;


    // 现在内存范围可以运行时决定
    // 迭代器访问次数可以任意指定
    /*
    int size = 3;
    char *c_mem = new char[size] {'1', '2', '3'};
    std::unique_ptr<char[]> mem(c_mem);
    auto mem_begin = mem.get();
    auto mem_end = mem_begin + 10;
    int j = 0;
    for (auto it = mem_begin; it != mem_end; it++) {
        cout << j++;
        cout << *it;
    }

    */
#pragma pack(push,1)
    struct Data {
        char str[4];
        int index;
    };//8 * char
#pragma pack(pop)
    char *mem = new char[32];
    reinterpret_cast<Data *>(mem)[0] = {"111",1};
    reinterpret_cast<Data *>(mem)[1] = {"222",2};
    reinterpret_cast<Data *>(mem)[2] = {"333",3};
    reinterpret_cast<Data *>(mem)[3] = {"444",4};

    // 缺点是要分配一个索引数组, 存在性能问题
    int max = 4;
    vector<int> index = {0,1,2,3};
    iota(index.begin(), index.end(), 0);
    auto ans = lower_bound(index.begin(), index.end(), 3, [=](const int &a, const int &b) {
        cout << a << " " << b << endl;
        return reinterpret_cast<Data *>(mem)[a].index < reinterpret_cast<Data *>(mem)[b].index;
    });
    cout << *ans << " ";
    cout << (reinterpret_cast<Data *>(mem)[*ans]).str;

    // 接下来通过迭代器实现
    auto mem_it = MemoryIterator<char *, Data *>(mem, sizeof(Data), max);

    cout << "\nUse MemoryIterator:\n";
    for (auto it = mem_it.begin(); it != mem_it.end();it++) {
        cout << reinterpret_cast<Data *>(*it)->str << endl;
    }
    cout << "\nUse MemoryIterator for Random Access and Type:\n";
    // MemoryIterato<char *, Data *> mem_it_type(mem, sizeof(Data), max);
    auto mem_it_type = MemoryIterator<char *, Data *>(mem, sizeof(Data), max);
    cout << mem_it_type[1]->str << mem_it_type[3]->str << mem_it_type[0]->str << mem_it_type[2]->str << endl;

    cout << "\nDistance Test:\n";
    cout << distance(mem_it_type.begin(), mem_it_type.end());


    cout << "\nCompare Test:\n";
    auto cmp = [](const MemoryIterator<char *, Data *>::dereference_type &a, const MemoryIterator<char *, Data *>::dereference_type &b)->bool {
        return reinterpret_cast<Data *>(a)->index < reinterpret_cast<Data *>(b)->index;
        };
    cout << cmp(*mem_it.begin(), *mem_it.end());
    cout << cmp(*mem_it.begin(), *(mem_it.end() - mem_it.GetSize() + 1));

    cout << "\nlower_bound Test:\n";
    // comp(element, value) 
    auto result = lower_bound(mem_it.begin(), mem_it.end(), 7, [](const MemoryIterator<char *, Data *>::dereference_type &a, int b)->bool {
        cout << a->index << " " << b << endl;
        return a->index < b;
    });
    cout << (*result)->str << " " << distance(mem_it.begin(), result) << " " << mem_it.GetIndex() << endl;
    cout << *(result.end() + 1 + 1 + 1 - 1 - 1 - 1 - 1 - 1) << " " << (result.end() + 18) - (result.end() + 3) << endl;
    cout << distance((result.end() + 3), (result.end() + 18));

    cout << "\nCommon Usage\n";
    vector<int> vt = {1,2,3,4};
    cout << distance(vt.begin(), lower_bound(vt.begin(), vt.end(), 7, [](const int &a, const int &b) {
        return a < b;
        }));
    cout << distance(vt.begin(), upper_bound(vt.begin(), vt.end(), 1, [](const int &a, const int &b) {
        return a < b;
        }));

    cout << "\nOut of Bound Test\n";
    // index一直会变, 只是存取时加入判断逻辑
    cout << *(vt.end() + 1 + 1 + 1 - 1 - 1 - 1 - 1 - 1) << " " << (vt.end() + 18) - (vt.end() + 3) << endl;
    cout << distance((vt.end() + 3), (vt.end() + 18));


    cout << "\nPerformance Test:\n";
    // 1 GiB
    size_t buf_size = (1ULL << 30);
    size_t data_max = buf_size / sizeof(Data);
    char *buf = new char[buf_size];
    Data *data_store = new(buf)Data[data_max];
    auto data_it = MemoryIterator<char *, Data *>(buf, sizeof(Data), data_max);

    auto start_time = std::chrono::high_resolution_clock::now();
    // random_access_iterator_tag:0ms forward_iterator_tag:218ms
    cout << distance(data_it.begin(), data_it.end()) << " in ";
    auto end_time = std::chrono::high_resolution_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end_time - start_time);
    cout << duration.count() << "ms\n";

    return 0;
}
