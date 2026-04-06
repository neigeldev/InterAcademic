# Stage 1: Build
FROM node:20-alpine AS builder

# Carpeta de trabajo
WORKDIR /app

# Copiar package.json y package-lock.json / pnpm-lock.yaml
COPY package*.json ./

# Instalar dependencias
RUN npm ci

# Copiar todo el proyecto
COPY . .

# Build de producción
RUN npm run build -- --configuration production

# Stage 2: Serve
FROM nginx:alpine

# Copiar los archivos construidos desde el builder
COPY --from=builder /app/dist/interacademic-front /usr/share/nginx/html

# Copiar configuración personalizada de Nginx (opcional)
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Exponer el puerto
EXPOSE 80

# Comando por defecto
CMD ["nginx", "-g", "daemon off;"]
