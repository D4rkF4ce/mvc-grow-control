<img src="http://srv01.hightechnix.at/growcontrol/content/images/growcontrol-logo.png" alt="logo" />

# mvc-grow-monitor
Grow Monitor &amp; Grow Control based on MVC ASP.Net 4.5
<br />
WebTool used to control & monitor fans, a humdifier, watering, temperature and power plugs in a grow tent
<br />

## Hardware required
- Windows Server with IIS 10 / RaspberryPi4 with nginx WebServer (planned for upcoming release)
- MyStrom PowerPlugs (https://mystrom.ch/)
- Shelly H&amp;T Sensor (https://shelly.cloud/)
- For auto watering, we use GARDENA (https://www.gardena.com/)
<br />

## What's working
Control the MyStrom plugs via the internal network (HTTP), temperature &amp; humidity values are collected via the Shelly Cloud API (HTTPS + Auth. Token).
<br />
- Read correct values from: MyStrom Plug (EU), Shelly H&amp;T Sensor via Cloud
- Fully implemented SqLite Database
- DataCollector BackgroundTask to check device values
- Mailalarm
<br />
<br />

## Improvements
- Create an API for Shelly which sends the values to this API with parameters according shelly-docu (temp = 99 & hum = 48)
- Port the whole solution to .NetCore 3.1 (Raspberry support)
<br />
<br />

## Preview UI
<img src="preview.png" alt="preview" />
<br />
<br />

