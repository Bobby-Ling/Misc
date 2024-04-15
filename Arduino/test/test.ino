#include <ArduinoSTL.h>
#include <Cpp_Standard_Library.h>
#include <system_configuration.h>
#include <unwind-cxx.h>
#include <vcruntime.h>
#include <yvals_core.h>
#include <yvals.h>

#include <sstream>

class Motor
{
    int _port1, _port2;
    uint8_t _arg1, _arg2;

public:
    Motor() : _port1(-1), _port2(-1), _arg1(0), _arg2(0) {}
    Motor(int port1, int port2) : _port1(port1), _port2(port2), _arg1(0), _arg2(0)
    {
        analogWrite(_port1, _arg1);
        analogWrite(_port2, _arg2);
    }
    bool setMotor(uint8_t arg1, uint8_t arg2)
    {
        // if(_port1&&_port2){
        _arg1 = arg1;
        _arg2 = arg2;
        analogWrite(_port1, _arg1);
        analogWrite(_port2, _arg2);
        return true;
        // }
        return false;
    }
    bool setMotorRelative(int8_t offsetArg1, int8_t offsetArg2)
    {
        if (_port1 && _port2)
        {
            _arg1 += offsetArg1;
            _arg2 += offsetArg2;
            analogWrite(_port1, _arg1);
            analogWrite(_port2, _arg2);
            return true;
        }
        return false;
    }
    std::string toString()
    {
        char buf[50] = {0};
        sprintf(buf, "port1:%d port2:%d arg1:%d arg2:%d", _port1, _port2, _arg1, _arg2);
        // Serial.print(_arg1);
        // Serial.print(" ");
        // Serial.println(_arg2);
        return buf;
    }
    enum
    {
        LEFT,
        RIGHT,
        BOTH
    };
};

struct CarControl
{
    enum
    {
        ZERO,
        RIGHT_UP,
        RIGHT_DOWN,
        LEFT_UP,
        LEFT_DOWN
    };
    enum class MODE
    {
        AUTO,
        INSTRUCT,
        MANUAL,
    };
    MODE mode = MODE::AUTO;
    Motor motor[2] = {Motor{5, 6}, Motor{9, 10}};
    bool commandParser()
    {
        int choice;
        uint8_t args[2];
        int a, b;
        if (Serial.available())
        {
            auto cmd = Serial.readString();
            auto inputStream = std::stringstream(cmd.c_str());

            if (cmd.startsWith("A"))
            {
                mode = MODE::AUTO;
            }
            else if (cmd.startsWith("M"))
            {
                mode = MODE::MANUAL;
                char c;
                inputStream >> c;
                inputStream >> choice;
                inputStream >> a >> b;
                // args[0] >> args[1];
                args[0] = a;
                args[1] = b;
            }
        }
        if (mode == MODE::AUTO)
        {
            autoRoute();
            return true;
        }
        else if (mode == MODE::MANUAL)
        {
            manualRoute(choice, args);
            return true;
        }
        return true;
    }
    void manualRoute(int choice, uint8_t args[2])
    {
        switch (choice)
        {
        case Motor::LEFT:
            motor[0].setMotor(args[0], args[1]);
            Serial.print("LEFT ");
            Serial.println(motor[0].toString().c_str());
            break;
        case Motor::RIGHT:
            Serial.print("RIGHT ");
            motor[1].setMotor(args[0], args[1]);
            Serial.println(motor[0].toString().c_str());
            break;
        case Motor::BOTH:
            Serial.print("BOTH ");
            motor[0].setMotor(args[0], args[1]);
            motor[1].setMotor(args[0], args[1]);
            Serial.println(motor[0].toString().c_str());
        default:
            break;
        }
    }
    void autoRoute()
    {
        int sensor[5] = {
            0,
            digitalRead(14),
            digitalRead(16),
            digitalRead(18),
            digitalRead(17)};

        int sensorAnalogRead[5] = {
            0,
            analogRead(14),
            analogRead(16),
            analogRead(18),
            analogRead(17)};

            
        Serial.println("---------------");
        // Serial.println("RIGHT_UP " + String(sensor[RIGHT_UP]));
        // Serial.println("RIGHT_DOWN " + String(sensor[RIGHT_DOWN]));
        // Serial.println("LEFT_UP " + String(sensor[LEFT_UP]));
        // Serial.println("LEFT_DOWN " + String(sensor[LEFT_DOWN]));
        Serial.println("RIGHT_UP " + String(sensor[RIGHT_UP]));
        Serial.println("RIGHT_DOWN " + String(sensor[RIGHT_DOWN]));
        Serial.println("LEFT_UP " + String(sensor[LEFT_UP]));
        Serial.println("LEFT_DOWN " + String(sensor[LEFT_DOWN]));
        Serial.println("---------------");

        motor[Motor::LEFT].setMotor(0, 255 * (sensor[RIGHT_DOWN] == 1 ? 1 : 0));
        motor[Motor::RIGHT].setMotor(0, 255 * (sensor[LEFT_DOWN] == 1 ? 1 : 0));
    }
};

CarControl carControl;
void setup()
{
    pinMode(14, INPUT); // RIGHT_UP  0 black
    pinMode(16, INPUT); // RIGHT_DOWN  0 black
    pinMode(18, INPUT); // LEFT_UP    0 black
    pinMode(17, INPUT); // LEFT_DOWN  0 black
    pinMode(5, OUTPUT); // left
    pinMode(6, OUTPUT);
    pinMode(9, OUTPUT); // right
    pinMode(10, OUTPUT);

    Serial.begin(115200);
}
enum
{
    ZERO,
    RIGHT_UP,
    RIGHT_DOWN,
    LEFT_UP,
    LEFT_DOWN
};

void loop()
{

    // analogWrite(6, 255 * (!var[1]));
    // analogWrite(10, 255 * (!var[3]));
    // Serial.println("RIGHT_UP "+String(var[RIGHT_UP]));
    // Serial.println("RIGHT_DOWN "+String(var[RIGHT_DOWN]));
    // Serial.println("LEFT_UP "+String(var[LEFT_UP]));
    // Serial.println("LEFT_DOWN "+String(var[LEFT_DOWN]));

    carControl.commandParser();
    // Serial.println("[LEFT_DOWN "+String(digitalRead(16))+" "+String(analogRead(16))+" ");
    // Serial.println("[RIGHT_DOWN "+String(digitalRead(16))+" "+String(analogRead(16))+" ");
    // Serial.println("[LEFT_UP "+String(digitalRead(18))+" "+String(analogRead(18))+" ");
    // Serial.println("[RIGHT_UP "+String(digitalRead(14))+" "+String(analogRead(14))+" ");

    delay(1000);
}