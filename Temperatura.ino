const int LM35 = A0;
const int R = 4;
const int G = 3;
const int B = 2;
float temp = 0.00;

void setup () {
  //analogReference(INTERNAL);
  Serial.begin(9600);
}

void loop() {
  temp = analogRead(LM35);
  // temp = temp / 9.31;
  temp = ((temp * 5000.0) / 1023) / 10;
  Serial.println(temp);
  delay(1000);
}