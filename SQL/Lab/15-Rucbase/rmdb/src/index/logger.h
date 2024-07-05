#pragma once
#include <string>
#include <fstream>
#include <sstream>
#include <mutex>
#include <cassert>
#include <chrono>
#include <ctime>
#include <iostream>
#include <iomanip>
#include <map>
#include <regex>

struct tm;
using namespace std;

#ifdef WIN32
#define localtime_r(_Time, _Tm) localtime_s(_Tm, _Time)
#endif

namespace logger {
    enum class Level { Disabled, Verbose, Info, Debug, Warning, Error, Fatal };
    static const map<Level, const char *> LevelStr =
    {
        { Level::Disabled, "Disabled" },
        { Level::Verbose, "Verbose   " },
        { Level::Info, "Info    " },
        { Level::Debug, "Debug   " },
        { Level::Warning, "Warning " },
        { Level::Error, "Error   " },
        { Level::Fatal, "Fatal   " },
    };

    class FileLogger;
    class ConsoleLogger;
    class BaseLogger;
    ostream &operator<< (ostream &stream, const tm *tm);

    class BaseLogger {
        class LogStream: public std::ostringstream {
            BaseLogger &m_oLogger;
            Level        m_nLevel;
        public:
            LogStream(BaseLogger &oLogger, Level nLevel)
                : m_oLogger(oLogger), m_nLevel(nLevel) {
            };
            LogStream(const LogStream &ls)
                : m_oLogger(ls.m_oLogger), m_nLevel(ls.m_nLevel) {
            };
            ~LogStream() {
                m_oLogger.endline(m_nLevel, std::move(str()));
            }
        };
        inline static Level filterLevel = Level::Info;
    public:
        BaseLogger() = default;
        virtual ~BaseLogger() = default;

        virtual LogStream operator()(Level nLevel = Level::Debug, bool isEnable = true) {
            return LogStream(*this, isEnable ? nLevel : Level::Disabled);
        }
        static void setFilterLevel(Level level) {
            filterLevel = level;
        }
        static Level getFilterLevel() {
            return filterLevel;
        }
    private:
        const tm *getLocalTime() {
            auto now = chrono::system_clock::now();
            auto in_time_t = chrono::system_clock::to_time_t(now);
            localtime_r(&in_time_t, &_localTime);
            return &_localTime;
        }
        void endline(Level nLevel, std::string &&oMessage) {
            _lock.lock();
            if (nLevel >= filterLevel) {
                output(getLocalTime(), LevelStr.find(nLevel)->second, oMessage.c_str());
            }
            _lock.unlock();
        }
        virtual void output(const tm *p_tm,
                            const char *str_level,
                            const char *str_message) = 0;
    private:
        std::mutex _lock;
        tm _localTime;
    };

    class ConsoleLogger: public BaseLogger {
        using BaseLogger::BaseLogger;
        virtual void output(const tm *p_tm,
                            const char *str_level,
                            const char *str_message) {
            cout << '[' << p_tm << ']'
                << '[' << str_level << "]"
                << "\t" << str_message << endl;
            cout.flush();
        }
    };

    class FileLogger: public BaseLogger {
    public:
        FileLogger(std::string filename) noexcept {
            string valid_filename(filename.size(), '\0');
            regex express("/|:| |>|<|\"|\\*|\\?|\\|");
            regex_replace(valid_filename.begin(),
                          filename.begin(),
                          filename.end(),
                          express,
                          "_");
            _file.open(valid_filename,
                       fstream::out | fstream::app | fstream::ate);
            assert(!_file.fail());
        }
        FileLogger(const FileLogger &) = delete;
        FileLogger(FileLogger &&) = delete;
        virtual ~FileLogger() {
            _file.flush();
            _file.close();
        }
    private:
        virtual void output(const tm *p_tm,
                            const char *str_level,
                            const char *str_message) {
            _file << '[' << p_tm << ']'
                << '[' << str_level << "]"
                << "\t" << str_message << endl;
            _file.flush();
        }
    private:
        std::ofstream _file;
    };

    // 友元函数不能继承
    inline ostream &operator<< (ostream &stream, const tm *tm) {
        return stream
            // << 1900 + tm->tm_year << '-'
            // << setfill('0') << setw(2) << tm->tm_mon + 1 << '-'
            // << setfill('0') << setw(2) << tm->tm_mday << ' '
            << setfill('0') << setw(2) << tm->tm_hour << ':'
            << setfill('0') << setw(2) << tm->tm_min << ':'
            << setfill('0') << setw(2) << tm->tm_sec;
    }
    // 防止重定义
    inline ConsoleLogger Log;
} // namespace logger