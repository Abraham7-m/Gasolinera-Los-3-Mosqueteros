#include <Wire.h>
#include <LiquidCrystal_I2C.h>

LiquidCrystal_I2C lcd(0x27, 16, 2);

const int bombas[4] = {2, 3, 4, 5};

unsigned long tiempoFin[4] = {0, 0, 0, 0};

bool tanqueLleno[4] = {false, false, false, false};

void setup()
{
  Serial.begin(9600);

  // LCD
  lcd.init();
  lcd.backlight();

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Bienvenidos a");

  lcd.setCursor(0, 1);
  lcd.print("Gasolinera");

  delay(3000);

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Los 3");

  lcd.setCursor(0, 1);
  lcd.print("Mosqueteros");

  delay(3000);

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Bombas");

  lcd.setCursor(0, 1);
  lcd.print("Activas");

  // Bombas
  for (int i = 0; i < 4; i++)
  {
    pinMode(bombas[i], OUTPUT);
    digitalWrite(bombas[i], LOW);
  }

  Serial.println("Sistema listo");
}

void loop()
{
  if (Serial.available())
  {
    String dato = Serial.readStringUntil('\n');
    dato.trim();

    int coma = dato.indexOf(',');

    if (coma > 0)
    {
      int bomba = dato.substring(0, coma).toInt();
      int segundos = dato.substring(coma + 1).toInt();

      if (bomba >= 1 && bomba <= 4)
      {
        int indice = bomba - 1;

        // DETENER
        if (segundos == 0)
        {
          digitalWrite(bombas[indice], LOW);

          tiempoFin[indice] = 0;
          tanqueLleno[indice] = false;

          Serial.print("Bomba ");
          Serial.print(bomba);
          Serial.println(" apagada");
        }

        // TANQUE LLENO
        else if (segundos == 999)
        {
          digitalWrite(bombas[indice], HIGH);

          tiempoFin[indice] = 0;
          tanqueLleno[indice] = true;

          Serial.print("Bomba ");
          Serial.print(bomba);
          Serial.println(" tanque lleno");
        }

        // PREPAGO
        else
        {
          digitalWrite(bombas[indice], HIGH);

          tanqueLleno[indice] = false;

          tiempoFin[indice] =
              millis() + ((unsigned long)segundos * 1000UL);

          Serial.print("Bomba ");
          Serial.print(bomba);
          Serial.print(" por ");
          Serial.print(segundos);
          Serial.println(" segundos");
        }
      }
    }
  }

  // Revisar tiempos de prepago
  for (int i = 0; i < 4; i++)
  {
    if (!tanqueLleno[i] &&
        tiempoFin[i] > 0 &&
        millis() >= tiempoFin[i])
    {
      digitalWrite(bombas[i], LOW); //Apagar

      tiempoFin[i] = 0;

      Serial.print("Bomba ");
      Serial.print(i + 1);
      Serial.println(" finalizada");
    }
  }
}