<img src="http://srv01.hightechnix.at/growcontrol/content/images/growcontrol-logo.png" alt="logo" />

# mvc-grow-monitor
Grow Monitor &amp; Grow Control based on MVC ASP.Net 4.5
<br />
<br />
MVC WebTool used to control & monitor fans, a humdifier, watering, temperature and power plugs in a grow tent.
<br />

## Hardware required
- Windows Server with IIS 10
- MyStrom PowerPlugs (https://mystrom.ch/)
- Shelly H&amp;T Sensor (https://shelly.cloud/)
- For auto watering, we use a GARDENA-System (https://www.gardena.com/)
<br />

## What's working
Control the MyStrom plugs via the internal network (HTTP), temperature &amp; humidity values are collected via the Shelly Cloud API.
<br />
- Read correct values from: MyStrom Plug (EU), Shelly H&amp;T Sensor via Cloud
- Fully implemented SqLite Database
- DataCollector BackgroundTask to check device values every Minute
- Data History Option
- Mailalarm-Manager
<br />
<br />

## Improvements
- Create an API for Shelly which sends the values to this API with parameters according shelly-docu (temp=99&hum=48)
- Raspberry support with nginx: Port the whole solution to .NetCore 3.1
<br />
<br />

## Preview UI
Current UI development state, fully touch compatible in desktop and mobile responsive design:
<br />
<br />
<img src="preview.png" alt="preview" />
<br />
<br />
Please note: We are still in a very early development phase. Please be careful with your power cabling and timer. We accept no liability for damage to materials or plants.
<br />

## Be a part of it
Do you want to help? With pleasure! For more information visit our project homepage or write us a message.
<br />
<br />
