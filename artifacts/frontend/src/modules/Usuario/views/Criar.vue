<script setup lang="ts">
import { ref, computed, onBeforeMount } from 'vue'
import { useRoute } from 'vue-router'
import {
  criarUsuario,
  obterUsuario,
  atualizarUsuario
} from '../controllers/usuario'
import { useUiStore } from '@/stores/ui'
import type { ValidationResultFunction } from '@/utils/regras'

const route = useRoute()

const modo = computed<'criar' | 'editar'>(() => {
  if (route.params.id) {
    return 'editar'
  }
  return 'criar'
})

const ui = useUiStore()

const id = ref('')
const nome = ref('')
const _email = ref('')
const senha = ref('')


const primeiraMaiuscula: ValidationResultFunction = (novoNome: string) => {
  if (/^[A-Z].*$/.test(novoNome)) {
    return true
  }
  return 'O nome deve começar com uma letra maiúscula'
}

const regrasNome = [primeiraMaiuscula]

const nomeValido = ref(false)

const updateNomeValido = (novoValor: boolean) => {
  nomeValido.value = novoValor
}

const descricao = ref('')

const criar = async () => {
  if (!nomeValido.value) {
    ui.exibirAlerta({
      text: 'Por favor, corrija os campos incorretos.',
      color: 'error'
    })
    return false
  }
  const sucesso = await criarUsuario({
    nome: nome.value,
    _email: _email.value,
    senha: senha.value

  })
  if (sucesso) {
    nome.value = ''
    _email.value = ''
    senha.value = ''

  }
  return true
}

const atualizar = async () => {
  if (!nomeValido.value) {
    ui.exibirAlerta({
      text: 'Por favor, corrija os campos incorretos.',
      color: 'error'
    })
    return false
  }

  const sucesso = await atualizarUsuario({
    Id: id.value,
    nome: nome.value,
    _email: _email.value,
    senha: senha.value

  })
  return true
}

const dispatchBotao = async () => {
  if (modo.value === 'criar') {
    return await criar()
  }
  return await atualizar()
}

onBeforeMount(async () => {
  if (modo.value === 'editar') {
    const routeId: string = Array.isArray(route.params.id) ? route.params.id[0] : route.params.id
    const cls = await obterUsuario(routeId)
    id.value = cls.Id
    nome.value = cls.nome
    _email.value = cls._email
    senha.value = cls.senha

  }
})
</script>

<template>
  <card class="w-md">
<text-input
  class="w-full"
  placeholder="Nome"
  v-model="nome"
  :rules="regrasNome"
  @validationUpdate="updateNomeValido"
/>
<text-input
  class="w-full"
  placeholder="_email"
  v-model="_email"
/>
<text-input
  class="w-full"
  placeholder="Senha"
  v-model="senha"
/>

    <div class="flex justify-end">
      <p-button
        @click="dispatchBotao"
      >
        {{ modo === 'criar' ? 'Registrar' : 'Atualizar' }}
      </p-button>
    </div>
  </card>
</template>