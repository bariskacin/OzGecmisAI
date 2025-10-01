import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
      server: {
        proxy: {
          '/api': {
            target: 'http://localhost:5215',
            changeOrigin: true,
            // secure: false removed as not needed for HTTP
          },
        },
      },
})
