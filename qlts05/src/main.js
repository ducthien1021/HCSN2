import { createApp } from "vue";
import App from "./App.vue";
import router from "./router/router.js";
import MISAIcon from "./components/base/icon/MISAIcon.vue";
import MISANumberInput from "./components/base/input/MISANumberInput.vue";
import MISASearchInput from "./components/base/input/MISASearchInput.vue";
import MISASelectInput from "./components/base/input/MISASelectInput.vue";
import MISAIconButton from "./components/base/button/MISAIconButton.vue";
import MISANormalButton from "./components/base/button/MISANormalButton.vue";
import MISABaseInput from "./components/base/input/MISABaseInput.vue";
import MISATable from "./components/base/table/MISATable.vue";
import MISAAddPropertyForm from "./components/form/MISAAddPropertyForm.vue";
import emitter from "tiny-emitter/instance";
import MISAResource from "./helpers/resources.js";
import icons from "./helpers/icons.js";
const app = createApp(App);
app.config.warnHandler = function (msg, vm, trace) {
  if (msg.startsWith("Invalid prop")) {
    return;
  }
  console.warn(msg, vm, trace);
};

app.component(MISAIcon);
app.component(MISANumberInput);
app.component(MISASearchInput);
app.component(MISASelectInput);
app.component(MISAIconButton);
app.component(MISANormalButton);
app.component(MISABaseInput);
app.component(MISATable);
app.component(MISAAddPropertyForm);

app.config.globalProperties.$_emitter = emitter;
app.config.globalProperties.$_MISAResource = MISAResource;
app.config.globalProperties.$_LANGCODE = "VN";
app.config.globalProperties.$_icons = icons;
app.config.globalProperties.$_imgUrl = require("@/assets/icon/qlts-icon.svg");
app.config.globalProperties.$_imageUrl = "@/assets/icon/qlts-icon.svg";
app.use(router);
app.mount("#app");
