import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ConfigurationManager } from "../../envs/configuration-manager";
import { RouterLink } from "@angular/router";

@Component({
  selector: "app-products",
  imports: [RouterLink],
  templateUrl: "./products.html",
  styleUrl: "./products.less"
})
export class Products implements OnInit
{
    public Ctrl: Products = this;
    public Items: any[] = [];

    constructor(
        protected HttpClient: HttpClient,
        protected Config: ConfigurationManager,
    )
    {

    }

    ngOnInit(): void {
        this.LoadList();
    }

    protected LoadList(): void
    {
        var url = this.Config.RootApi + "Product";
        this.HttpClient
            .get<any[]>(url)
            .subscribe({
                next: (data) => {
                    this.Items = data;
                },
                error: (err) => {
                    console.error("Error loading products:", err);
                }
            });
    }
}
