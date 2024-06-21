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
include CMakeFiles/rucbase.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/rucbase.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/rucbase.dir/flags.make

CMakeFiles/rucbase.dir/rucbase.o: CMakeFiles/rucbase.dir/flags.make
CMakeFiles/rucbase.dir/rucbase.o: ../rucbase.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/home/kylin/rucbase-lab/src/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/rucbase.dir/rucbase.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/rucbase.dir/rucbase.o -c /home/kylin/rucbase-lab/src/rucbase.cpp

CMakeFiles/rucbase.dir/rucbase.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/rucbase.dir/rucbase.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /home/kylin/rucbase-lab/src/rucbase.cpp > CMakeFiles/rucbase.dir/rucbase.i

CMakeFiles/rucbase.dir/rucbase.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/rucbase.dir/rucbase.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /home/kylin/rucbase-lab/src/rucbase.cpp -o CMakeFiles/rucbase.dir/rucbase.s

# Object files for target rucbase
rucbase_OBJECTS = \
"CMakeFiles/rucbase.dir/rucbase.o"

# External object files for target rucbase
rucbase_EXTERNAL_OBJECTS =

rucbase: CMakeFiles/rucbase.dir/rucbase.o
rucbase: CMakeFiles/rucbase.dir/build.make
rucbase: parser/libparser.a
rucbase: execution/libexecution.a
rucbase: system/libsystem.a
rucbase: record/librecord.a
rucbase: transaction/libtransaction.a
rucbase: recovery/librecovery.a
rucbase: system/libsystem.a
rucbase: record/librecord.a
rucbase: transaction/libtransaction.a
rucbase: recovery/librecovery.a
rucbase: index/libindex.a
rucbase: storage/libstorage.a
rucbase: CMakeFiles/rucbase.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/home/kylin/rucbase-lab/src/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable rucbase"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/rucbase.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/rucbase.dir/build: rucbase

.PHONY : CMakeFiles/rucbase.dir/build

CMakeFiles/rucbase.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/rucbase.dir/cmake_clean.cmake
.PHONY : CMakeFiles/rucbase.dir/clean

CMakeFiles/rucbase.dir/depend:
	cd /home/kylin/rucbase-lab/src/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /home/kylin/rucbase-lab/src /home/kylin/rucbase-lab/src /home/kylin/rucbase-lab/src/build /home/kylin/rucbase-lab/src/build /home/kylin/rucbase-lab/src/build/CMakeFiles/rucbase.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/rucbase.dir/depend
