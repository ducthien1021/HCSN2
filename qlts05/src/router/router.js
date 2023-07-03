import { createRouter, createWebHistory } from "vue-router";
import PropertyManagement from "../views/PropertyManagement.vue";

const routes = [
  { path: "/", component: PropertyManagement, name: "Home" },
  {
    path: "/property-management",
    component: PropertyManagement,
    name: "PropertyManagement",
  },
  { path: "/property", component: PropertyManagement, name: "Property" },
  { path: "/tool", component: PropertyManagement, name: "Tool" },
  { path: "/about", component: PropertyManagement, name: "About" },
  { path: "/contact", component: PropertyManagement, name: "Contact" },
  { path: "/login", component: PropertyManagement, name: "Login" },
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});

export default router;
