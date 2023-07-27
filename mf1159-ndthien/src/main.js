import { createApp } from 'vue'
import App from './App.vue'
import MISACombobox from '@/components/base/MISACombobox.vue'
import MISAPagination from '@/components/base/MISAPagination.vue'
import MISAButton from '@/components/base/MISAButton.vue'
import MISACheckbox from '@/components/base/MISACheckbox.vue'

import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import vi from 'element-plus/dist/locale/vi.mjs'

import router from '@/router/router.js'

const app = createApp(App)
app.use(ElementPlus, {
    locale: vi,
})

// Khai báo components sử dụng global
app.component("MISACombobox", MISACombobox)
app.component("MISAButton", MISAButton)
app.component("MISAPagination", MISAPagination)
app.component("MISACheckbox", MISACheckbox)

app.use(router)
app.mount('#app')