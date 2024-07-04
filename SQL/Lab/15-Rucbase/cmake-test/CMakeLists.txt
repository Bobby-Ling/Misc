cmake_minimum_required(VERSION 3.0.0)
project(cmake_mult VERSION 0.1.0 LANGUAGES C CXX)

# add_executable(cmake_mult1 main.cpp)
# add_executable(begin_test begin_test.cpp)
add_executable(allocator allocator.cpp)

# # Minimum CMake version required to build this project
# cmake_minimum_required(VERSION 3.10)

# # Project name and version
# project(YourProjectName VERSION 1.0)

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

