# Aula 06 — Guia para Abertura do Projeto Unity

## Requisitos
- **Unity Hub**
- **Versão do Unity**: Unity 6 (`6000.5.9f1` ou compatível)
- Plataformas suportadas: **macOS** e **Windows**

---

## Como Abrir e Executar

1. **Descompactar o arquivo `.zip`** em uma pasta de sua escolha.
2. Abra o **Unity Hub**.
3. Clique em **Add** (ou **Add project from disk**) no canto superior direito.
4. Selecione a pasta descompactada do projeto.
5. Clique no projeto para abri-lo.
   > **Nota:** Na primeira abertura em outro computador, o Unity criará automaticamente a pasta local `Library/` e baixará os pacotes definidos no Package Manager (incluindo o plugin do Google Cardboard XR). Essa compilação inicial de cache leva de 1 a 3 minutos dependendo da máquina.
6. No painel **Project** (abaixo), abra a cena do projeto em:
   - `Assets` ➔ `Scenes` ➔ **`SampleScene.unity`**
   - Ou as cenas do Cardboard em `Assets/Samples/Google Cardboard XR Plugin for Unity/.../Scenes/`
7. Clique em **▶ Play** para testar.

---

## Por que este pacote é reduzido?
Este arquivo contém estritamente o necessário para abrir o projeto em qualquer máquina:
- `Assets/`: Cenas, scripts C#, materiais, prefabs e configurações do Cardboard.
- `Packages/`: Manifesto de dependências (`manifest.json` com Universal RP, Cardboard XR Plugin, etc.).
- `ProjectSettings/`: Configurações de tags, camadas, física, XR e versão do editor (`ProjectVersion.txt`).

Pastas pesadas e temporárias geradas pelo próprio Unity (`Library/` de ~8.8 GB, `Temp/`, `Logs/`, `UserSettings/` e arquivos de IDE como `.csproj`/`.sln`) foram intencionalmente excluídas, pois são recriadas de forma limpa pelo Unity ao abrir em qualquer sistema.
