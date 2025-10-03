<script setup lang="ts">
import { computed, ref } from 'vue'
import { RouterView, useRoute } from 'vue-router'
import SidebarMenu from './components/SidebarMenu.vue'
import HelloWorld from './components/HelloWorld.vue'

const expanded = ref(true)
const route = useRoute()

const subtitle = computed(() => {
  if (!route.name) return ''
  const name = String(route.name)
  const spaced = name.replace(/([A-Z])/g, ' $1').trim()

  return spaced.charAt(0).toUpperCase() + spaced.slice(1) + ' Page'
})
const title = "Hello Daniel"
</script>

<template>
  <div class="layout" >
    <SidebarMenu :expanded @toggle="expanded = !expanded" />
    
    <main class="content">
      <header class="topbar">
        <HelloWorld :title :subtitle />
      </header>
      <section class="page">
        <RouterView />
      </section>
    </main>
  </div>
</template>

<style scoped>
.layout { min-height: 100vh; }

.toggle {
  position: absolute; right: -10px; top: 12px;
  width: 24px; height: 24px; border-radius: 999px;
  border: none; cursor: pointer; background: #334155; color: #e5e7eb;
}

.brand { display: flex; align-items: center; gap: .75rem; margin-bottom: 1rem; }
.brand-text { font-weight: 600; white-space: nowrap; }
.logo { display: block; }

/* icon + label */
.icon {
  display: inline-flex;
  width: 20px;
  height: 20px;
  align-items: center;
  justify-content: center;
}

/* menu container */
.menu {
  display: grid;
  gap: .25rem;
  margin-top: .75rem;
}

.content {
  /* fills the rest of the screen beside the fixed sidebar */
  margin-left: 240px;                 /* 64px when collapsed */
  width: calc(100vw - 240px);         /* prevents narrow column */
  min-height: 100vh;
  transition: margin-left .2s ease, width .2s ease;
  overflow-x: hidden;
  display: flex;
  flex-direction: column;
}

.topbar { padding: 1rem 1.25rem; border-bottom: 1px solid #ffffff1a; }
.page { padding: 1.25rem; }
</style>
