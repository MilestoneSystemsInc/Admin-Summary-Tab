Words from the author

Author : Justin Butterworth - jub@milestone.dk

This plugin is provided as is and with minimal documentation and testing. The plugin is designed to be installed in the management client and adds a log tab to each device (Camera, input, output, microphone, speaker). This log tab contains relative logs for the selected device taken from the system and audit log in the Management Client. You can choose to include parent elements (hardware and recording server) via a check box at the top of the tab. You can also export both tables to CSV is required/desired.

Installation (installed on the management Client)

Create a new directory under C:\Program Files\Milestone\MIPPlugins for example logtab.

Paste the plugin.def and the Device_Logging_Tab.dll into that folder. Start the management Client

Uninstall

Incase of issues please stop the mangement client enter the folder you created in C:\Program Files\Milestone\MIPPlugins
and rename the plugin.def to plugin.def.disabled to stop the plugin from being loaded.


Logging

There is performance logging in the MIPTrace.log, usually located in C:\ProgramData\Milestone\XProtect Management Client\Logs

Troubleshooting

You may find the the dlls are blocked by windows, in this case, right click on the dll, select properties and uncheck the "blocked" check box.
