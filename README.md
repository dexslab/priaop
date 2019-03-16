# Priority / AOP

So when I was developing for a particular server i decided to combine 2 Great Resouces into one and make them run EVEN Better by implementing them with C# and the new Replicated Convar system(Thanks Vespura). Introducing a newly redesigned Priority Cooldown and Area of Patrol script that is FULLY customizable. below you will find the the list of Convars used to set everything and the ability to set it how you want. I have included a config file similar to the one used in vMenu to automatically set the convars to there default versions customize this file as you see fit and enjoy countless hours of Quality RP. Now on to the goodness

## Priority Cooldown

Priority Cooldown has been revamped to include a dynamic countdown with color customization and the abilty to set countdown length in MINUTES. You can also like the classic script reset the cooldown to 0. I have also added Friendly Fire control so players cannot kill other players. This also includes a Bypass option for staff members only(Will not be changed).

### Common Convars

|Convar| Replicated|Default|Description|
|--|--|--|--|
|priaop_allowed_groups|false|admin,mod|Comma separated list of groups allowed to use PriAOP commands|
|priaop_permission_denied|false|Nice try, you dont have permission to use this command|Message shown to player attempting to use command without permission|

### Commands

|slash(/) command|Description|
|--|--|
| resetpc | Resets priority cooldown to 0 (Friendly fire is **ENABLED**)|
| inprogress| Sets the priority Cooldown to in progress so you can basically put them on hold while you handle someones stupidity.(Friendly fire is **ENABLED**)|
|onhold|Sets Priority Cooldown to be on Hold so you do not have to deal with someones stupidity.(Friendly fire is **DISABLED**)|
|cooldown <time in mins>|This sets the priority cooldown in minutes and starts a dynamic countdown timer on players screens(Friendly fire is **DISABLED**)|
|pcbypass|Allows Friendly Fire to be Enabled until Priority Cooldown is set again|

### Convars

These can be set using server console, RCON, or the various commands above

|Convar| Replicated|Default|Description|
|--|--|--|--|
|priority_cooldown|true|priority_onhold_message|Current Priority Cooldown message displayed to players|
|priority_status|true|onhold|Current Priority Cooldown status used to set messages and control Friendly Fire|
|priority_onhold_message|false|Priorities are on HOLD|Message for priority on hold|
|priority_onhold_color|false|245,19,23,255|Color for priority on hold message (color must be set as r,g,b,a no extra characters and numbers only)|
|priority_cooldown_message|false|Priority Cooldown: %s until the next priority can begin|Message for priority on cooldown (%s is the timer)|
|priority_cooldown_color|false|245,157,50,255|Color for priority on cooldown message
|priority_inprogress_message|false|Priority in Progress|Message for priority in progress|
|priority_inprogress_color|false|19,23,245,255|Color for priority in progress message|
|priority_finished_message|false|Peace time has ended|Message for priority cooldown complete|
|priority_finished_color|false|80,252,12,255|Color for priority cooldown complete message|

## Area of Patrol

Area of Patrol has also been modified and made simpler to use. First you can use any amount of word you woul

### Commands

|slash(/) command|Description  |
|--|--|
| aop <area you specify> | Sets AOP to what ever you put (supports multiple words)|
|aopp| Sets AOP to Paleto Bay|
|aops|Sets AOP to Sandy Shores|
|aopb|Sets AOP to Blaine County|
|aopl|Sets AOP to Los Santos County|
|aopc|Sets AOP to Los Santos|
|aopsw|Sets AOP to Statewide|

### Convars

These can be set using server console, RCON, or the various commands above

|Convar| Replicated|Default|Description|
|--|--|--|--|
|current_aop|true|Los Santos|The current area of play|
|aop_chat_spam_count|false|3|How many times to spam AOP in change when it changes|
|aop_chat_sender_name|false|^1AOP|Name in chat box when spamming anything AOP related|
|aop_chat_message|false|Area of Patrol has moved to ^1^_%s^r^7 please finish your RP and move to new AOP location|Message for priority on hold|
|aop_sandy|false|Sandy Shores|The name of Sandy Shores|
|aop_city|false|Los Santos|The name of Los Santos|
|aop_blaine|false|Blaine County|The name of Blaine County|
|aop_lossantos|false|Los Santos County|The name of Los Santos County|
|aop_paleto|false|Paleto Bay|The name of Paleto Bay|
|aop_state|false|Statewide|The name of State|