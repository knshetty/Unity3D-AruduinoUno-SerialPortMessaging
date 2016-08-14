#define BaudRate 9600
#define LEDPin    13

char incomingOption;

void setup()
{
  pinMode(LEDPin, OUTPUT);
  Serial.begin(BaudRate);
}

void loop()
{
     incomingOption = Serial.read();
     
     switch(incomingOption){
        case '1':
          // Turn ON LED
          digitalWrite(LEDPin, HIGH);
          break;
        case '0':
          // Turn OFF LED
          digitalWrite(LEDPin, LOW);
          break;
     }
}