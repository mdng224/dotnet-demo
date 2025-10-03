<script setup lang="ts">
import { defineEmits } from 'vue';

const props = defineProps<{ expanded: boolean }>();
const emit = defineEmits(['toggle']);
</script>

<template>
    <aside class="sidebar" :class="{ collapsed: !props.expanded }">
      <button class="toggle-btn" @click="emit('toggle')">
        <svg v-if="expanded" xmlns="http://www.w3.org/2000/svg" class="icon" viewBox="0 0 24 24" fill="none" stroke="currentColor">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7" />
        </svg>
        <svg v-else xmlns="http://www.w3.org/2000/svg" class="icon" viewBox="0 0 24 24" fill="none" stroke="currentColor">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
        </svg>
      </button>

      <nav class="menu">
       <RouterLink to="/cmd-tlm-server" class="item" aria-label="CmdTlmServer">
        <span class="icon">
          <!-- Server icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <rect x="3" y="4" width="18" height="6" rx="2" stroke-width="2"/>
            <rect x="3" y="14" width="18" height="6" rx="2" stroke-width="2"/>
            <circle cx="8" cy="7" r="1" stroke-width="2"/>
            <circle cx="8" cy="17" r="1" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">CmdTlmServer</span>
      </RouterLink>

      <RouterLink to="/limits-monitor" class="item" aria-label="Limits Monitor">
        <span class="icon">
          <!-- Triangle warning icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <polygon points="12,2 22,20 2,20" stroke-width="2" fill="none"/>
            <line x1="12" y1="8" x2="12" y2="13" stroke-width="2"/>
            <circle cx="12" cy="16" r="1" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Limits Monitor</span>
      </RouterLink>

      <RouterLink to="/command-sender" class="item" aria-label="Command Sender">
        <span class="icon">
          <!-- Send/arrow icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <line x1="22" y1="2" x2="11" y2="13" stroke-width="2"/>
            <polygon points="22,2 15,22 11,13 2,9" stroke-width="2" fill="none"/>
          </svg>
        </span>
        <span class="label">Command Sender</span>
      </RouterLink>

      <RouterLink to="/script-runner" class="item" aria-label="Script Runner">
        <span class="icon">
          <!-- Play/run icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <polygon points="5,3 19,12 5,21" stroke-width="2" fill="none"/>
          </svg>
        </span>
        <span class="label">Script Runner</span>
      </RouterLink>

      <RouterLink to="/packet-viewer" class="item" aria-label="Packet Viewer">
        <span class="icon">
          <!-- List icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <line x1="8" y1="6" x2="21" y2="6" stroke-width="2"/>
            <line x1="8" y1="12" x2="21" y2="12" stroke-width="2"/>
            <line x1="8" y1="18" x2="21" y2="18" stroke-width="2"/>
            <circle cx="4" cy="6" r="1" stroke-width="2"/>
            <circle cx="4" cy="12" r="1" stroke-width="2"/>
            <circle cx="4" cy="18" r="1" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Packet Viewer</span>
      </RouterLink>

      <RouterLink to="/telemetry-viewer" class="item" aria-label="Telemetry Viewer">
        <span class="icon">
          <!-- Monitor icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <rect x="3" y="4" width="18" height="14" rx="2" stroke-width="2"/>
            <line x1="8" y1="20" x2="16" y2="20" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Telemetry Viewer</span>
      </RouterLink>

      <RouterLink to="/telemetry-grapher" class="item" aria-label="Telemetry Grapher">
        <span class="icon">
          <!-- Line chart icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <polyline points="4 14 8 10 12 14 16 6 20 10" stroke-width="2" fill="none"/>
            <circle cx="4" cy="14" r="1" stroke-width="2"/>
            <circle cx="8" cy="10" r="1" stroke-width="2"/>
            <circle cx="12" cy="14" r="1" stroke-width="2"/>
            <circle cx="16" cy="6" r="1" stroke-width="2"/>
            <circle cx="20" cy="10" r="1" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Telemetry Grapher</span>
      </RouterLink>

      <RouterLink to="/data-extractor" class="item" aria-label="Data Extractor">
        <span class="icon">
          <!-- Download/box icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <rect x="4" y="4" width="16" height="16" rx="2" stroke-width="2"/>
            <polyline points="8 12 12 16 16 12" stroke-width="2" fill="none"/>
            <line x1="12" y1="8" x2="12" y2="16" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Data Extractor</span>
      </RouterLink>

      <RouterLink to="/data-viewer" class="item" aria-label="Data Viewer">
        <span class="icon">
          <!-- Table/grid icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <rect x="3" y="3" width="18" height="18" rx="2" stroke-width="2"/>
            <line x1="3" y1="9" x2="21" y2="9" stroke-width="2"/>
            <line x1="3" y1="15" x2="21" y2="15" stroke-width="2"/>
            <line x1="9" y1="3" x2="9" y2="21" stroke-width="2"/>
            <line x1="15" y1="3" x2="15" y2="21" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Data Viewer</span>
      </RouterLink>

      <RouterLink to="/handbooks" class="item" aria-label="Handbooks">
        <span class="icon">
          <!-- Book icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <path d="M4 19.5A2.5 2.5 0 0 1 6.5 17H20" stroke-width="2"/>
            <path d="M4 4.5A2.5 2.5 0 0 1 6.5 7H20" stroke-width="2"/>
            <rect x="4" y="4" width="16" height="16" rx="2" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Handbooks</span>
      </RouterLink>

      <RouterLink to="/table-manager" class="item" aria-label="Table Manager">
        <span class="icon">
          <!-- Table icon (same as Data Viewer) -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <rect x="3" y="3" width="18" height="18" rx="2" stroke-width="2"/>
            <line x1="3" y1="9" x2="21" y2="9" stroke-width="2"/>
            <line x1="3" y1="15" x2="21" y2="15" stroke-width="2"/>
            <line x1="9" y1="3" x2="9" y2="21" stroke-width="2"/>
            <line x1="15" y1="3" x2="15" y2="21" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Table Manager</span>
      </RouterLink>

      <RouterLink to="/calendar" class="item" aria-label="Calendar">
        <span class="icon">
          <!-- Calendar icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <rect x="3" y="5" width="18" height="16" rx="2" stroke-width="2"/>
            <line x1="16" y1="3" x2="16" y2="7" stroke-width="2"/>
            <line x1="8" y1="3" x2="8" y2="7" stroke-width="2"/>
            <line x1="3" y1="9" x2="21" y2="9" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Calendar</span>
      </RouterLink>

      <RouterLink to="/Autonomic" class="item" aria-label="Autonomic">
        <span class="icon">
          <!-- Robot icon -->
          <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
            <rect x="7" y="8" width="10" height="8" rx="2" stroke-width="2"/>
            <circle cx="12" cy="12" r="1" stroke-width="2"/>
            <line x1="12" y1="4" x2="12" y2="8" stroke-width="2"/>
            <line x1="9" y1="4" x2="15" y2="4" stroke-width="2"/>
          </svg>
        </span>
        <span class="label">Autonomic</span>
      </RouterLink>
      </nav>
    </aside>
</template>

<style scoped>
.icon svg { width: 20px; height: 20px; }

/* each link */
.item {
  display: flex;
  align-items: center;
  gap: .625rem;
  padding: .625rem .75rem;
  border-radius: .5rem;
  color: #e5e7eb;
  text-decoration: none;
  line-height: 1;
  transition: background-color .15s ease, color .15s ease, transform .05s ease;
}

/* optional: subtle press effect */
.item:active { transform: translateY(1px); }
.item:hover { background: #273244; }                 /* hover */
.item.router-link-active {
  background: #111827;                               /* active */
  color: #ffffff;
  font-weight: 600;
}

.sidebar.collapsed ~ .content {
  margin-left: 64px;
}

.sidebar {
  position: fixed;
  top: 0;
  left: 0;
  height: 100vh;
  width: 240px;
  background: #1f2937;
  color: #fff;
  transition: width 0.2s ease;
  padding: 1rem;
  box-sizing: border-box;
  overflow-x: hidden; /* avoid text peeking */
}

.sidebar.collapsed {
  width: 64px;
}

.sidebar.collapsed .brand-text,
.sidebar.collapsed .label {
  display: none;
}

/* keep nav links centered when collapsed */
.sidebar.collapsed nav {
  display: flex;
  flex-direction: column;
  align-items: center;
}

/* hide text when collapsed */
.sidebar.collapsed .brand-text,
.sidebar.collapsed .label { display: none; }

.toggle-btn {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 36px;
  height: 36px;
  border: none;
  border-radius: 8px;
  background-color: #111827; /* dark slate */
  color: #e5e7eb;            /* light text */
  cursor: pointer;
  transition: background-color 0.2s, transform 0.2s;
  margin: 0.5rem;
}

.toggle-btn:hover {
  background-color: #1f2937; /* slightly lighter */
  transform: scale(1.05);
}

.toggle-btn:active {
  transform: scale(0.95);
}

.toggle-btn .icon {
  width: 20px;
  height: 20px;
  stroke-width: 2;
}
</style>
