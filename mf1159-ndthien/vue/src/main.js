import { createApp } from 'vue'
import App from './App.vue'
import router from '@/router/router.js'
import MISACombobox from '@/components/base/MISACombobox.vue'
import MISAPagination from '@/components/base/MISAPagination.vue'
import MISAButton from '@/components/base/MISAButton.vue'
import MISACheckbox from '@/components/base/MISACheckbox.vue'
import MISAInput from '@/components/base/MISAInput.vue'
import MISAFormGroup from '@/components/base/MISAFormGroup.vue'
import MISAInputNumber from '@/components/base/MISAInputNumber.vue'
import MISALoadingTable from '@/components/base/MISALoadingTable.vue'
import MISAEmptyTable from '@/components/base/MISAEmptyTable.vue'
import MISADatePicker from '@/components/base/MISADatePicker.vue'
import MISADialog from '@/components/base/MISADialog.vue'
import MISALoadingSpinner from '@/components/base/MISALoadingSpinner.vue'

import MISAResource from './helpers/Resource'
import MISAEnum from './helpers/Enum'
import MISAFunctions from './helpers/Functions'

import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import vi from 'element-plus/dist/locale/vi.mjs'

// set first day of week to Monday
import dayjs from 'dayjs'
dayjs.Ls.en.weekStart = 1

const app = createApp(App)
app.use(ElementPlus, {
    locale: vi,
})

// Khai báo components sử dụng global
app.component("MISACombobox", MISACombobox)
    .component("MISAButton", MISAButton)
    .component("MISAPagination", MISAPagination)
    .component("MISACheckbox", MISACheckbox)
    .component("MISAInput", MISAInput)
    .component("MISAFormGroup", MISAFormGroup)
    .component("MISAInputNumber", MISAInputNumber)
    .component("MISALoadingTable", MISALoadingTable)
    .component("MISAEmptyTable", MISAEmptyTable)
    .component("MISADatePicker", MISADatePicker)
    .component("MISADialog", MISADialog)
    .component("MISALoadingSpinner", MISALoadingSpinner)

app.config.globalProperties.$_MISAResource = MISAResource;
app.config.globalProperties.$_MISAEnum = MISAEnum;
app.config.globalProperties.$_MISAFunctions = MISAFunctions;

app.use(router)
app.mount('#app')