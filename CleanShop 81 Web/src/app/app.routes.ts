import { Routes } from "@angular/router";
import { Orders } from "./orders/orders";
import { Products } from "./products/products";

export const routes: Routes = [];

routes.push(
    {
        path: "order",
        component: Orders,
    });

routes.push(
    {
        path: "product",
        component: Products,
    });
