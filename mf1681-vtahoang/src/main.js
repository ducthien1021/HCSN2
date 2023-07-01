import "./css/main.css";
import TheNavbar from "./components/layout/TheNavbar/TheNavbar.vue";
import TheHeader from "./components/layout/TheHeader/TheHeader.vue";
import { createApp } from "vue";
import App from "./App.vue";

const app = createApp(App);

app.component("TheNavbar", TheNavbar);
app.component("TheHeader", TheHeader);

createApp(App).mount("#app");
