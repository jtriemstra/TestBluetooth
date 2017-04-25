void setup() {
  // put your setup code here, to run once:
  delay(5000);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.print("This is a test");
  delay(1000);
}
