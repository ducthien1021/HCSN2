import { createRouter, createWebHistory } from 'vue-router'
import AssetPage from '@/components/views/asset/AssetPage.vue'
import MISACombobox from '@/components/base/MISACombobox.vue'

const routers = [{
        path: "/cbx",
        name: "MISACombobox",
        component: MISACombobox
    },
    {
        path: "/asset",
        name: "AssetPage",
        component: AssetPage
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes: routers
})

export default router;