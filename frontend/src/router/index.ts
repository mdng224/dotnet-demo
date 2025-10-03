import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/login', name: 'login', component: () => import('../views/LoginView.vue'), meta: { guestOnly: true } },

    { path: '/', name: 'home', component: HomeView, },
    { path: '/cmd-tlm-server',  name: 'cmdTlmServer',   component: () => import('../views/CmdTlmServerView.vue') },
    { path: '/limits-monitor',  name: 'limitsMonitor',  component: () => import('../views/LimitsMonitorView.vue') },
    { path: '/command-sender',  name: 'commandSender',  component: () => import('../views/CommandSenderView.vue') },
    { path: '/script-runner',   name: 'scriptRunner',   component: () => import('../views/ScriptRunnerView.vue') },
    { path: '/packet-viewer',   name: 'packetViewer',   component: () => import('../views/PacketViewerView.vue') },
    {
      path: '/telemetry-viewer',
      name: 'telemetryViewer',
      component: () => import('../views/TelemetryViewerView.vue')
    },
    {
      path: '/telemetry-grapher',
      name:'telemetryGrapher',
      component: () => import('../views/TelemetryGrapherView.vue')
    },
    { path: '/data-extractor',  name: 'dataExtractor',  component: () => import('../views/DataExtractorView.vue') },
    { path: '/data-viewer',     name: 'dataViewer',     component: () => import('../views/DataViewerView.vue') },
    { path: '/handbooks',       name: 'handbooks',      component: () => import('../views/HandbooksView.vue') },
    { path: '/table-manager',   name: 'tableManager',   component: () => import('../views/TableManagerView.vue') },
    { path: '/calendar',        name: 'calendar',       component: () => import('../views/CalendarView.vue') },
    { path: '/autonomic',       name: 'autonomic',      component: () => import('../views/AutonomicView.vue') },
    { path: '/:pathMatch(.*)*', name: 'notFound',       component: () => import('../views/NotFoundView.vue') },
  ],
})

export default router
