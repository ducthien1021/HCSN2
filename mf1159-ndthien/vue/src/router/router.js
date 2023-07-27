import { createRouter, createWebHistory } from 'vue-router'
import AssetPage from '@/components/views/asset/AssetPage.vue'
import MISADialog from '@/components/base/MISADialog.vue'

const routers = [{
        path: "/dialog",
        name: "Dialog",
        component: MISADialog
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