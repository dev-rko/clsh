import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ConfigurationManager } from "../../envs/configuration-manager";
import { RouterLink } from "@angular/router";

@Component({
    selector: "app-orders",
    imports: [RouterLink],
    templateUrl: "./orders.html",
    styleUrl: "./orders.less"
})
export class Orders implements OnInit
{
    public Ctrl: Orders = this;
    public Items: any[] = [];

    constructor(
        protected HttpClient: HttpClient,
        protected Config: ConfigurationManager,
    )
    {

    }

    ngOnInit(): void
    {
        this.LoadList();
    }

    protected LoadList(): void
    {
        var url = this.Config.RootApi + "Order";
        this.HttpClient
            .get<any[]>(url)
            .subscribe({
                next: (data) =>
                {
                    this.Items = data;
                },
                error: (err) =>
                {
                    console.error("Error loading orders:", err);
                }
            });
    }
}
