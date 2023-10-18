 import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";

 export default class Hub {
   
    constructor() {
        this.connection = new HubConnectionBuilder()
            .withUrl('https://localhost:7140/chat')
            .configureLogging(LogLevel.Information)
            .build();
    }
 }