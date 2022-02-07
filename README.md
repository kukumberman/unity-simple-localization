# unity-simple-localization
 
Simple implementation of localization/internationalization (i18n) for Unity games

## Preview

## Features
- Display static and dynamic values
- Change language dynamically, reload/restart is not required
- Data could be stored as Google sheet and easily converted to proper format by using external tool

## Ideas
- Instead of converting json data in runtime — convert it (at editor stage) to plain key-value entries and store in `ScriptableObject` for each language separately
- Add support for resources (sprites, audio, ...), key-value format (value is stored as relavite path to resource in project directory) and then in editor convert it to `ScriptalbeObject` container as `Dictionary<string, UnityEngine.Object>`
