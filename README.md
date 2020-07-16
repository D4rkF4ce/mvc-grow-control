<img src="http://srv01.hightechnix.at/growcontrol/content/images/growcontrol-logo.png" alt="logo" />

# mvc-grow-monitor
Grow Monitor &amp; Grow Control based on MVC ASP.Net 4.5 and CSharp
<br />
<br />
MVC WebTool used to control & monitor fans, a humdifier, watering, temperature and power plugs in a grow tent.
<br />
<br />

## Hardware required
- Windows Server with IIS 10
- MyStrom PowerPlugs (https://mystrom.ch/)
- Shelly H&amp;T Sensor (https://shelly.cloud/)
- For auto watering, we use a GARDENA-System (https://www.gardena.com/)
<br />
<br />

## What's working
Control the MyStrom plugs via the internal network (HTTP), temperature &amp; humidity values are collected via the Shelly Cloud API.
<br />
- Read correct values from: MyStrom Plug (EU), Shelly H&amp;T Sensor via Cloud
- Fully implemented SqLite Database
- DataCollector BackgroundTask to check device values every Minute
- Data History Option
- Treshold Values for Temperatur &amp; Humidity, Sunset &amp; Sunrise
- Mailalarm-Manager
<br />
<br />

## Improvements
- Create an API for Shelly which sends the values to this API with parameters according to shelly-docu <br />(https://shelly-api-docs.shelly.cloud/#shelly-h-amp-t) 
- Raspberry support with nginx: Port the whole solution to .NetCore 3.1<br /> (https://thomaslevesque.com/2018/04/17/hosting-an-asp-net-core-2-application-on-a-raspberry-pi/)
- CleanUp History after 7 days
- Electricity forecast and costs
- Update Bootstrap to latest version
- Implement jQueryUI
<br />
<br />

## Preview UI
Current UI development state, fully touch compatible in desktop and mobile responsive design:
<br />
<br />
<img src="preview.png" alt="preview" />
<br />
<br />
Current work in progress (available in version 0.2.x) show plant details on button click:
<br />
<br />
<img src="preview-plants.JPG" alt="preview" />
<br />
<br />

## Please Note
We are still in a very early development phase. Please be careful with your power cabling and timer. We accept no liability for damage to materials or plants.
<br />
<br />

## Release Plan
Alpha Tests currently running on version <b>0.1.7502</b>
<br />
Beta Tests planned for AUG-2020
<br />
First productive Release planned for SEP-2020
<br />
<br />

## Be a part of it
Do you want to help? With pleasure! For more information visit our project homepage or write us a message.
<br />
<br />
