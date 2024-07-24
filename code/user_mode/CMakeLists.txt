cmake_minimum_required(VERSION 3.0.0)
project(user_mode VERSION 0.1.0 LANGUAGES C CXX)

add_subdirectory(pid)
add_subdirectory(write_file)

# # Specify the C++ standard
set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED True)

# # Add the executable
# add_executable(YourExecutableName main.cpp)

# # Optionally, you can specify compiler flags
# if(CMAKE_BUILD_TYPE STREQUAL "Debug")
#     target_compile_options(YourExecutableName PRIVATE -g)
# endif()
# if(CMAKE_BUILD_TYPE STREQUAL "Release")
#     target_compile_options(YourExecutableName PRIVATE -O3)
# endif()

# # Optionally, you can specify include directories, link libraries, etc.
# # include_directories(${CMAKE_SOURCE_DIR}/include)
# # target_link_libraries(YourExecutableName your_library)


# 指定Glibc库目录（如果需要包含路径，可以使用include_directories）
include_directories(/opt/glibc-2.35/include)

# link_directories(pid /opt/glibc-2.35/lib)
# link_directories(write_file /opt/glibc-2.35/lib)
# 全局设置链接目录
link_directories(/opt/glibc-2.35/lib)

# 设置RPATH
# target_link_libraries(pid PRIVATE -Wl,-rpath=/opt/glibc-2.35/lib)
# target_link_libraries(write_file PRIVATE -Wl,-rpath=/opt/glibc-2.35/lib)\
# Valid scopes are GLOBAL, DIRECTORY, TARGET, SOURCE, TEST, CACHE, INSTALL
set_property(
    GLOBAL PROPERTY
    BUILD_RPATH "/opt/glibc-2.35/lib"
    INSTALL_RPATH "/opt/glibc-2.35/lib"
    INSTALL_RPATH_USE_LINK_PATH TRUE
)
