<template>
  <q-layout view="lHh Lpr lFf">
    <q-page-container>
      <q-input
        outlined
        placeholder="Informe seu nome"
        v-model="message.name"
        class="q-mt-sm q-pa-sm"
        dense
      >
      </q-input>

      <ChatComponent :messages="messages" :userActual="message.name"/>

      <q-input
        outlined
        @keyup.enter="send"
        placeholder="Digite uma mensagem"
        v-model="message.body"
        class="q-mt-xl q-pa-sm"
        dense
      >

       <template v-slot:append>
          <q-icon size="sm" name="search"/>
        </template>
      
      </q-input>
    </q-page-container>
  </q-layout>
</template>

<script>
import { ref, reactive, onMounted } from 'vue'
import ChatComponent from './components/ChatComponent.vue'
import Hub from "./Hub";   

export default {
  name: 'LayoutDefault',

  components: {
    ChatComponent
  },

  setup () {

      let messages = ref([]);
      let message = reactive({
        name:"",
        body:""
      });
      
      let _hub = new Hub();

      function send() {
        if(message.body =="") return;
       
        _hub.connection.invoke("SendMessageAsync", message);
        message.body ="";
      }

      onMounted(() => {
        _hub.connection.start()
        .then(() => {
           console.log("Connected");
          
             _hub.connection.on("ReceivedMessageAsync", (msg) => {
              console.log(msg);
              messages.value.push(msg);
          });

        })
        .catch(e => console.log("Connection failed", e));
      })

    return {
     send,
     messages,
     message
    }
  }
}
</script>
