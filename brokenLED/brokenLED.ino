
#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define PIN 3

#define NUM_LEDS 228

#define BRIGHTNESS 50

Adafruit_NeoPixel strip = Adafruit_NeoPixel(NUM_LEDS, PIN, NEO_GRB + NEO_KHZ800);

byte inputByte_0;

byte inputByte_1;

byte inputByte_2;

byte inputByte_3;

void setup() {
  Serial.begin(9600);
  strip.setBrightness(BRIGHTNESS);
  strip.begin();
  strip.show();
}

void loop() {
    if (Serial.available() == 4) 
  {
    inputByte_0 = Serial.read();
    inputByte_1 = Serial.read();     
    inputByte_2 = Serial.read();   
    inputByte_3 = Serial.read();
    strip.setPixelColor(inputByte_3, strip.Color(inputByte_0,inputByte_1,inputByte_2,50));
    strip.setPixelColor((inputByte_3 + 1) % NUM_LEDS, 0);
    strip.setPixelColor((inputByte_3 + 2) % NUM_LEDS, 0);
    strip.setPixelColor((inputByte_3 + 3) % NUM_LEDS, 0);
    strip.setPixelColor((inputByte_3 + 4) % NUM_LEDS, 0);
    strip.setPixelColor((inputByte_3 + 5) % NUM_LEDS, 0);
    strip.setPixelColor((inputByte_3 + 6) % NUM_LEDS, 0);
    strip.show();
    delay(1);
  }
  inputByte_0 = 0;
  inputByte_1 = 0;  
  inputByte_2 = 0;   
  inputByte_3 = 0;
}   
