#include <stdio.h>
#include <list>
#include <unordered_map>
#include <iostream>
#include <iterator> 
#include <algorithm>
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

    cout << " end";
    return 0;
}
