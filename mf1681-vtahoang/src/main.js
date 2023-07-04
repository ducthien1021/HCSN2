import "./css/main.css";
import TheHeader from "./components/layout/TheHeader/TheHeader.vue";
import TheNavbar from "./components/layout/TheNavbar/TheNavbar.vue";
import { createApp } from "vue";
import App from "./App.vue";
import MISAEnum from "./helper/enum.js";
import MISAResources from "./helper/resources";
import handler from "./helper/handler";
import axios from "axios";

const app = createApp(App);

app.component("TheNavbar", TheNavbar);
app.component("TheHeader", TheHeader);

app.config.globalProperties.$_MISAResources = MISAResources;
app.config.globalProperties.$_MISAEnum = MISAEnum;
app.config.globalProperties.numberHandler = handler.numberHandler;
app.config.globalProperties.dateHandler = handler.dateHandler;
app.config.globalProperties.maxios = axios;

app.mount("#app");
