import { ref } from 'vue'
import apiClient from '@/api'

const isAuthed = ref<boolean | null>(null)
let inFlight: Promise<void> | null = null

export const ensureAuthState = async (force = false): Promise<boolean> => {
  if (force) { isAuthed.value = null; inFlight = null }
  if (typeof isAuthed.value === 'boolean') return isAuthed.value

  if (!inFlight) {
    inFlight = apiClient.get('/me')
      .then(() => { isAuthed.value = true })
      .catch(() => { isAuthed.value = false })
      .finally(() => { inFlight = null })
  }
  await inFlight
  return isAuthed.value!
}

export const useAuth = () => ({ isAuthed, ensureAuthState })
