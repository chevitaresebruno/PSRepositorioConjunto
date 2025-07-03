<script lang="ts" setup>
import NavGroup from './NavGroup.vue'
import NavItem from './NavItem.vue'
</script>

<template>
  <aside class="flex flex-col h-full px-4 py-6 text-white lg:px-2">
    <section class="flex flex-col grow items-center w-full h-14 px-5 space-x-2 bg-gray-0 z-30 lg:static lg:flex-col lg:justify-start lg:px-0 lg:space-x-0 lg:space-y-2 lg:bg-transparent">
      <!-- <NavItem to="/" label="Página inicial" /> -->

<NavGroup label="Usuario">
  <NavItem :to="{ name: 'usuario-home' }" label="Listar" />
  <NavItem :to="{ name: 'usuario-criar' }" label="Criar" />
</NavGroup><NavGroup label="Categoria">
  <NavItem :to="{ name: 'categoria-home' }" label="Listar" />
  <NavItem :to="{ name: 'categoria-criar' }" label="Criar" />
</NavGroup><NavGroup label="Tarefa">
  <NavItem :to="{ name: 'tarefa-home' }" label="Listar" />
  <NavItem :to="{ name: 'tarefa-criar' }" label="Criar" />
</NavGroup>

    </section>
  </aside>
</template>