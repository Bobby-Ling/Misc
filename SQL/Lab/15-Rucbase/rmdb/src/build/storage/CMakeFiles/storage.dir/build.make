# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.16

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /usr/bin/cmake

# The command to remove a file.
RM = /usr/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /home/kylin/rucbase-lab/src

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /home/kylin/rucbase-lab/src/build

# Include any dependencies generated for this target.
include storage/CMakeFiles/storage.dir/depend.make

# Include the progress variables for this target.
include storage/CMakeFiles/storage.dir/progress.make

# Include the compile flags for this target's objects.
include storage/CMakeFiles/storage.dir/flags.make

storage/CMakeFiles/storage.dir/disk_manager.o: storage/CMakeFiles/storage.dir/flags.make
storage/CMakeFiles/storage.dir/disk_manager.o: ../storage/disk_manager.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/kylin/rucbase-lab/src/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object storage/CMakeFiles/storage.dir/disk_manager.o"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/storage.dir/disk_manager.o -c /home/kylin/rucbase-lab/src/storage/disk_manager.cpp

storage/CMakeFiles/storage.dir/disk_manager.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/storage.dir/disk_manager.i"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/kylin/rucbase-lab/src/storage/disk_manager.cpp > CMakeFiles/storage.dir/disk_manager.i

storage/CMakeFiles/storage.dir/disk_manager.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/storage.dir/disk_manager.s"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/kylin/rucbase-lab/src/storage/disk_manager.cpp -o CMakeFiles/storage.dir/disk_manager.s

storage/CMakeFiles/storage.dir/buffer_pool_manager.o: storage/CMakeFiles/storage.dir/flags.make
storage/CMakeFiles/storage.dir/buffer_pool_manager.o: ../storage/buffer_pool_manager.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/kylin/rucbase-lab/src/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Building CXX object storage/CMakeFiles/storage.dir/buffer_pool_manager.o"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/storage.dir/buffer_pool_manager.o -c /home/kylin/rucbase-lab/src/storage/buffer_pool_manager.cpp

storage/CMakeFiles/storage.dir/buffer_pool_manager.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/storage.dir/buffer_pool_manager.i"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/kylin/rucbase-lab/src/storage/buffer_pool_manager.cpp > CMakeFiles/storage.dir/buffer_pool_manager.i

storage/CMakeFiles/storage.dir/buffer_pool_manager.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/storage.dir/buffer_pool_manager.s"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/kylin/rucbase-lab/src/storage/buffer_pool_manager.cpp -o CMakeFiles/storage.dir/buffer_pool_manager.s

storage/CMakeFiles/storage.dir/__/replacer/lru_replacer.o: storage/CMakeFiles/storage.dir/flags.make
storage/CMakeFiles/storage.dir/__/replacer/lru_replacer.o: ../replacer/lru_replacer.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/kylin/rucbase-lab/src/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_3) "Building CXX object storage/CMakeFiles/storage.dir/__/replacer/lru_replacer.o"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/storage.dir/__/replacer/lru_replacer.o -c /home/kylin/rucbase-lab/src/replacer/lru_replacer.cpp

storage/CMakeFiles/storage.dir/__/replacer/lru_replacer.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/storage.dir/__/replacer/lru_replacer.i"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/kylin/rucbase-lab/src/replacer/lru_replacer.cpp > CMakeFiles/storage.dir/__/replacer/lru_replacer.i

storage/CMakeFiles/storage.dir/__/replacer/lru_replacer.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/storage.dir/__/replacer/lru_replacer.s"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/kylin/rucbase-lab/src/replacer/lru_replacer.cpp -o CMakeFiles/storage.dir/__/replacer/lru_replacer.s

storage/CMakeFiles/storage.dir/__/replacer/clock_replacer.o: storage/CMakeFiles/storage.dir/flags.make
storage/CMakeFiles/storage.dir/__/replacer/clock_replacer.o: ../replacer/clock_replacer.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/kylin/rucbase-lab/src/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_4) "Building CXX object storage/CMakeFiles/storage.dir/__/replacer/clock_replacer.o"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/storage.dir/__/replacer/clock_replacer.o -c /home/kylin/rucbase-lab/src/replacer/clock_replacer.cpp

storage/CMakeFiles/storage.dir/__/replacer/clock_replacer.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/storage.dir/__/replacer/clock_replacer.i"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/kylin/rucbase-lab/src/replacer/clock_replacer.cpp > CMakeFiles/storage.dir/__/replacer/clock_replacer.i

storage/CMakeFiles/storage.dir/__/replacer/clock_replacer.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/storage.dir/__/replacer/clock_replacer.s"
	cd /home/kylin/rucbase-lab/src/build/storage && /usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/kylin/rucbase-lab/src/replacer/clock_replacer.cpp -o CMakeFiles/storage.dir/__/replacer/clock_replacer.s

# Object files for target storage
storage_OBJECTS = \
"CMakeFiles/storage.dir/disk_manager.o" \
"CMakeFiles/storage.dir/buffer_pool_manager.o" \
"CMakeFiles/storage.dir/__/replacer/lru_replacer.o" \
"CMakeFiles/storage.dir/__/replacer/clock_replacer.o"

# External object files for target storage
storage_EXTERNAL_OBJECTS =

storage/libstorage.a: storage/CMakeFiles/storage.dir/disk_manager.o
storage/libstorage.a: storage/CMakeFiles/storage.dir/buffer_pool_manager.o
storage/libstorage.a: storage/CMakeFiles/storage.dir/__/replacer/lru_replacer.o
storage/libstorage.a: storage/CMakeFiles/storage.dir/__/replacer/clock_replacer.o
storage/libstorage.a: storage/CMakeFiles/storage.dir/build.make
storage/libstorage.a: storage/CMakeFiles/storage.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/home/kylin/rucbase-lab/src/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_5) "Linking CXX static library libstorage.a"
	cd /home/kylin/rucbase-lab/src/build/storage && $(CMAKE_COMMAND) -P CMakeFiles/storage.dir/cmake_clean_target.cmake
	cd /home/kylin/rucbase-lab/src/build/storage && $(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/storage.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
storage/CMakeFiles/storage.dir/build: storage/libstorage.a

.PHONY : storage/CMakeFiles/storage.dir/build

storage/CMakeFiles/storage.dir/clean:
	cd /home/kylin/rucbase-lab/src/build/storage && $(CMAKE_COMMAND) -P CMakeFiles/storage.dir/cmake_clean.cmake
.PHONY : storage/CMakeFiles/storage.dir/clean

storage/CMakeFiles/storage.dir/depend:
	cd /home/kylin/rucbase-lab/src/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/kylin/rucbase-lab/src /home/kylin/rucbase-lab/src/storage /home/kylin/rucbase-lab/src/build /home/kylin/rucbase-lab/src/build/storage /home/kylin/rucbase-lab/src/build/storage/CMakeFiles/storage.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : storage/CMakeFiles/storage.dir/depend
