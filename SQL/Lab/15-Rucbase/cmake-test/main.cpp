#include <stdio.h>
#include <list>
#include <ranges>
#include <iterator> 
#include <unordered_map>
#include <iostream>
#include <algorithm>
#include <stdint.h>
using namespace std;


int main(int, char **) {
    list<int> link_list;
    link_list.push_back(1);
    link_list.push_back(2);
    link_list.push_back(3);
    link_list.push_back(4);
    copy(link_list.begin(), link_list.end(), ostream_iterator <int>(cout, " "));
    auto it = find(link_list.begin(), link_list.end(), 3);
    cout << *it;
    while (it != link_list.end()) {
        cout << *it++ << " ";
    }
    auto it1 = link_list.begin();
    auto it2 = ++it1;
    auto it3 = ++it1;
    auto it4 = ++it1;
    cout <<"["<< *it1 << *it2 << *it3 << *it4 << *it1<<"]";



    unordered_map<int, string> hashmap;
    hashmap.reserve(2);
    hashmap[1] = "a";
    hashmap[2] = "b";
    hashmap.erase(2);
    std::for_each(hashmap.begin(), hashmap.end(), [](const auto &item) {
        std::cout << item.first << ": " << item.second << " ";
    });

    cout << "\n-----------------------------\n\n";

    char *arr;
    arr = new char[10];

#pragma pack(push,1)
    struct st { uint8_t a; char b[5]; uint32_t c; };
    reinterpret_cast<st *> (arr)[0] = {0x12,"123\0",0x78563412};
    // -exec x/10xb arr
    // 0x55555557a3e0:	0x12	0x31	0x32	0x33	0x00	0x00	0x12	0x34
    // 0x55555557a3e8:	0x56	0x78
    printf("%s", arr);
    // reinterpret_cast<struct { char b[5];uint8_t a; uint32_t c; } * > (arr)[0] = {"123\0",0x12,0x78563412};
    // error: types may not be defined in casts
#pragma pack(pop)

    // auto it_arr = std::ranges


    return 0;
}
