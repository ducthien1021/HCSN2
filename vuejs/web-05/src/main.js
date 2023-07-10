import { createApp } from "vue";
import App from "./App.vue";
import ElementPlus from "element-plus";
import "element-plus/dist/index.css";
import MISAInput from "./components/base/input/MISAInput.vue";
import MISACombobox from "./components/base/combobox/MISACombobox.vue";
import MISACombobox2 from "./components/base/combobox/MISACombobox2.vue";
import MISAButton from "./components/base/button/MISAButton.vue";
import MISATable from "./components/base/table/MISATable.vue";
import MISAForm from "./components/base/form/MISAForm.vue";
import MISALoading from "./components/base/loading/MISALoading.vue";
import MISAResource from "./js/common/resource";
import router from "./router/router";
import MISAEnum from "./js/common/enum.js";
import Paginate from "vuejs-paginate-next";

const app = createApp(App);
app.component("MISAInput", MISAInput);
app.component("MISACombobox", MISACombobox);
app.component("MISACombobox2", MISACombobox2);
app.component("MISAButton", MISAButton);
app.component("MISATable", MISATable);
app.component("MISAForm", MISAForm);
app.component("MISALoading", MISALoading);
app.component("MISAPaginate", Paginate);
app.config.globalProperties.$_MISAEnum = MISAEnum;
app.config.globalProperties.$_MISAResource = MISAResource;
app.config.globalProperties.$_LANG_CODE = "VN";

app.use(ElementPlus);
app.use(router);
app.mount("#app");
