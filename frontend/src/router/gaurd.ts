// src/router/guard.ts (or inline where you create the router)
import router from './index'
import { useAuth } from '@/composables/useAuth'


router.beforeEach(async (to) => {

  const { isAuthed, ensureAuthState } = useAuth()

  // pages that don't require auth
  const publicPaths = new Set(['/login'])

  const requiresAuth = !publicPaths.has(to.path)
  await ensureAuthState()

  if (requiresAuth && !isAuthed.value)
    return { path: '/login', query: { redirect: to.fullPath } }

  if (to.meta.guestOnly && isAuthed.value) {
    // already logged in → bounce away from login
    return { path: (to.query.redirect as string) || '/' }
  }

  return true
})
