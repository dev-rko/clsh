//import * as Ext from "@extensions";
//import * as I from "@abstractions";
import { Injectable } from "@angular/core";
import { Environment } from "./environment";

@Injectable({
    providedIn: "root"
})
export class ConfigurationManager
{
    public IsProduction = false;
    public EnvName = "..missing..";
    public RootApi = "../api/";

    constructor()
    {
        // use predefined environment variables compiled into bundle
        // then override environment variables by config downloaded from server - the server config is last/winner

        const targetEnvironment = Environment as unknown as { [name: string]: unknown }; // use object as key value


        const target = this as unknown as { [name: string]: unknown }; // use object as key value

        // merge variables into configuration-manager from merged environment object
        for (const key of Object.keys(targetEnvironment))
        {
            target[key] = targetEnvironment[key];
        };
    }
}
