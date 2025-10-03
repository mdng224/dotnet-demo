// src/main.ts
import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

// Side-effect import: registers router.beforeEach in src/router/guard.ts
import './router/gaurd'

const app = createApp(App)

app.use(createPinia())
app.use(router)

// Wait for initial navigation (so guards/redirects happen before first paint)
router.isReady().then(() => app.mount('#app'))
