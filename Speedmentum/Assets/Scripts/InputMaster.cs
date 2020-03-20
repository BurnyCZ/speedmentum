// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""8bc95a94-cff4-4c59-b1ba-039397a6fc1d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2a8a1a9b-7537-4828-8df5-628e197195b3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9cb6ca6f-df4d-4488-b985-cbe93e85bc94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookStraight"",
                    ""type"": ""Button"",
                    ""id"": ""ef7ae98e-75dc-4a05-995a-bd66ffc09442"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Button"",
                    ""id"": ""3a23db74-d2b9-4a37-9bee-55c817183f0e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WasForwardsPressed"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0936f5a8-4490-4665-80b5-0be0259fcc51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WasBackwardsPressed"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4f456ef3-1f79-4aff-9798-e7b8fe5d3e7c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WasRightPressed"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4c30a283-468d-4a4e-82b9-79549992801d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""WasLeftPressed"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8eded632-1b1a-494e-a2de-5936255fc3da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""982f7388-3fde-489e-b40b-5c60ed3d40bd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""12e43718-a421-45fa-bc64-ccf23e492951"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2623a4dc-2239-4e1c-9d86-b91a8b705dc2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0fc42a3e-2d1f-4057-ac13-272deb505a97"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cd9b7629-7fea-4247-b20f-baf5aa7a1ca0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a06b6e14-d1ae-44f0-82af-6cd9c2c6ed93"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bef7d571-92f9-4372-aec4-c46ce49e251e"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""LookStraight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00524718-ffab-4196-a370-5a935a7d7157"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""106948cb-092f-4934-8d6d-4da5cfca9fad"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe350358-ae8a-47e9-8465-e19e9475d7a2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""WasForwardsPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b901a284-8ad0-47e6-87c0-48445290b8ac"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""WasBackwardsPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6d94396-8e29-489d-be8c-6f83f969b5b4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""WasRightPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2ab0b67-c19c-4c83-bf78-c23198da3a3a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""WasLeftPressed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GuiControls"",
            ""id"": ""b570f838-d3ce-48c7-acd9-dcd3323c5a4e"",
            ""actions"": [
                {
                    ""name"": ""ChangeVelToFloat"",
                    ""type"": ""Button"",
                    ""id"": ""112b041b-e540-49ee-aa99-74ce06ae79a6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeVelMode"",
                    ""type"": ""Button"",
                    ""id"": ""21f0759e-d714-4ca1-97e0-bbbf0bb7402a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PauseKey"",
                    ""type"": ""Button"",
                    ""id"": ""3497098f-fd6e-481c-837d-6baad23284d1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShowMovementMenu"",
                    ""type"": ""Button"",
                    ""id"": ""01daf25f-52d2-4e2f-a99f-8f4275067462"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeKey"",
                    ""type"": ""Button"",
                    ""id"": ""e789db1d-f4fd-4576-804e-023f59acceaf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopKey"",
                    ""type"": ""Button"",
                    ""id"": ""78aebfed-ac13-45ba-b5de-fe889680f7c8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKey1"",
                    ""type"": ""Button"",
                    ""id"": ""e1ce9e05-6333-47bd-a283-3dc18a5cd87d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKey2"",
                    ""type"": ""Button"",
                    ""id"": ""e42cb6cf-d831-4502-bd72-eae81bf133ed"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKey3"",
                    ""type"": ""Button"",
                    ""id"": ""107ce672-4749-46a4-bc3e-49b226c70aa9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKey4"",
                    ""type"": ""Button"",
                    ""id"": ""ffe185d3-8a83-48e6-9c34-0205c629c78e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKey5"",
                    ""type"": ""Button"",
                    ""id"": ""05e1f22c-2f78-427e-8da6-77d2d417accb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKey6"",
                    ""type"": ""Button"",
                    ""id"": ""6f78ff23-24e0-4a26-806a-9419456da261"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKey7"",
                    ""type"": ""Button"",
                    ""id"": ""fe7ca5fb-8209-438a-aff1-3663c6c61cc5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKey8"",
                    ""type"": ""Button"",
                    ""id"": ""8ff4ae0f-9ff4-4beb-b10b-30b0aec75059"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKey9"",
                    ""type"": ""Button"",
                    ""id"": ""d6d5330b-469b-426b-9386-5898579b01a1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKeyF1"",
                    ""type"": ""Button"",
                    ""id"": ""d2d22723-355e-41ac-9236-af86e1c2b71f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKeyF2"",
                    ""type"": ""Button"",
                    ""id"": ""5ef58b69-1f76-4f0f-8006-b6c9847c9e6e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKeyF3"",
                    ""type"": ""Button"",
                    ""id"": ""cad166ea-9fd4-4717-b5a5-6dfbbe73e470"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKeyF4"",
                    ""type"": ""Button"",
                    ""id"": ""32736760-82a5-470a-8620-15b7c02c531a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKeyF5"",
                    ""type"": ""Button"",
                    ""id"": ""79db5c1b-cdcb-4d25-a06d-6ceddf53dc17"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKeyF6"",
                    ""type"": ""Button"",
                    ""id"": ""669b3d51-0f03-4e9f-8ee6-843322f36050"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKeyF7"",
                    ""type"": ""Button"",
                    ""id"": ""f7c0b7a8-8300-4e7f-a993-5804c5fe40b9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKeyF8"",
                    ""type"": ""Button"",
                    ""id"": ""cc19eadd-9846-4cdb-8366-e0edde0867f5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuKeyF9"",
                    ""type"": ""Button"",
                    ""id"": ""bc918bf8-680c-414b-8796-f91a3b78a7d4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d7ba4e62-ad5b-4045-9f8e-e8f1657ab702"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""ShowMovementMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a01a6f3-920a-4e5d-8c2a-dbfc7d48aafd"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKey1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""711416a3-7441-4472-8534-7bfec71647fd"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKey2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2927408-a509-4e81-8fb3-625c6d423048"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKey3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""27033264-be19-437f-93cc-29150b5fa724"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKey4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10d3766f-cbb8-47f5-868c-a75ed0f4695f"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKey5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc3b4c58-f467-419a-be3c-2b3b182de160"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKey6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29cef577-c9bd-42d1-93f4-5fb5171f8439"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKey7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a03f979-2ead-495e-a3a5-783972b87f51"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKey8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""128fed19-0b8f-4490-82f9-0b5918ddcfd3"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKey9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80515a73-6f0c-4e2b-9709-1f2907e69118"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKeyF1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a75a63ab-f990-41c6-926e-5bad9e70b96c"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKeyF2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9311858-b9db-4182-85ea-576378fc7d0d"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKeyF3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81a92092-ecb1-459d-bfdb-c0c71863ebaa"",
                    ""path"": ""<Keyboard>/f4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKeyF4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f80b9e21-62b9-4ed9-965d-147ca19c0f37"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKeyF5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62e28fc3-1744-4420-9588-439868782939"",
                    ""path"": ""<Keyboard>/f6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKeyF6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc38ec6b-3a41-478c-a1a1-74b29bd0b395"",
                    ""path"": ""<Keyboard>/f7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKeyF7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d62ecb41-d295-4658-a93e-dba8808c1c49"",
                    ""path"": ""<Keyboard>/f8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKeyF8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d716c8a-6792-4867-bd78-9485a7f5cfee"",
                    ""path"": ""<Keyboard>/f9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""MenuKeyF9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fc5df6e-6a86-4c13-a900-43a2c43c3b93"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""PauseKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75e23f0a-85d7-4ccf-99d0-d0828246b6a4"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""ChangeVelMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f26e4a9-2107-44f5-a309-431ecc5e592a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""ChangeVelToFloat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82056360-bb06-4404-8a25-6caa68fcd19e"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""StopKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ac777e6-02ee-4f4b-8be9-ad353323fc61"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and mouse"",
                    ""action"": ""ChangeKey"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and mouse"",
            ""bindingGroup"": ""Keyboard and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControls_LookStraight = m_PlayerControls.FindAction("LookStraight", throwIfNotFound: true);
        m_PlayerControls_Mouse = m_PlayerControls.FindAction("Mouse", throwIfNotFound: true);
        m_PlayerControls_WasForwardsPressed = m_PlayerControls.FindAction("WasForwardsPressed", throwIfNotFound: true);
        m_PlayerControls_WasBackwardsPressed = m_PlayerControls.FindAction("WasBackwardsPressed", throwIfNotFound: true);
        m_PlayerControls_WasRightPressed = m_PlayerControls.FindAction("WasRightPressed", throwIfNotFound: true);
        m_PlayerControls_WasLeftPressed = m_PlayerControls.FindAction("WasLeftPressed", throwIfNotFound: true);
        // GuiControls
        m_GuiControls = asset.FindActionMap("GuiControls", throwIfNotFound: true);
        m_GuiControls_ChangeVelToFloat = m_GuiControls.FindAction("ChangeVelToFloat", throwIfNotFound: true);
        m_GuiControls_ChangeVelMode = m_GuiControls.FindAction("ChangeVelMode", throwIfNotFound: true);
        m_GuiControls_PauseKey = m_GuiControls.FindAction("PauseKey", throwIfNotFound: true);
        m_GuiControls_ShowMovementMenu = m_GuiControls.FindAction("ShowMovementMenu", throwIfNotFound: true);
        m_GuiControls_ChangeKey = m_GuiControls.FindAction("ChangeKey", throwIfNotFound: true);
        m_GuiControls_StopKey = m_GuiControls.FindAction("StopKey", throwIfNotFound: true);
        m_GuiControls_MenuKey1 = m_GuiControls.FindAction("MenuKey1", throwIfNotFound: true);
        m_GuiControls_MenuKey2 = m_GuiControls.FindAction("MenuKey2", throwIfNotFound: true);
        m_GuiControls_MenuKey3 = m_GuiControls.FindAction("MenuKey3", throwIfNotFound: true);
        m_GuiControls_MenuKey4 = m_GuiControls.FindAction("MenuKey4", throwIfNotFound: true);
        m_GuiControls_MenuKey5 = m_GuiControls.FindAction("MenuKey5", throwIfNotFound: true);
        m_GuiControls_MenuKey6 = m_GuiControls.FindAction("MenuKey6", throwIfNotFound: true);
        m_GuiControls_MenuKey7 = m_GuiControls.FindAction("MenuKey7", throwIfNotFound: true);
        m_GuiControls_MenuKey8 = m_GuiControls.FindAction("MenuKey8", throwIfNotFound: true);
        m_GuiControls_MenuKey9 = m_GuiControls.FindAction("MenuKey9", throwIfNotFound: true);
        m_GuiControls_MenuKeyF1 = m_GuiControls.FindAction("MenuKeyF1", throwIfNotFound: true);
        m_GuiControls_MenuKeyF2 = m_GuiControls.FindAction("MenuKeyF2", throwIfNotFound: true);
        m_GuiControls_MenuKeyF3 = m_GuiControls.FindAction("MenuKeyF3", throwIfNotFound: true);
        m_GuiControls_MenuKeyF4 = m_GuiControls.FindAction("MenuKeyF4", throwIfNotFound: true);
        m_GuiControls_MenuKeyF5 = m_GuiControls.FindAction("MenuKeyF5", throwIfNotFound: true);
        m_GuiControls_MenuKeyF6 = m_GuiControls.FindAction("MenuKeyF6", throwIfNotFound: true);
        m_GuiControls_MenuKeyF7 = m_GuiControls.FindAction("MenuKeyF7", throwIfNotFound: true);
        m_GuiControls_MenuKeyF8 = m_GuiControls.FindAction("MenuKeyF8", throwIfNotFound: true);
        m_GuiControls_MenuKeyF9 = m_GuiControls.FindAction("MenuKeyF9", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_Jump;
    private readonly InputAction m_PlayerControls_LookStraight;
    private readonly InputAction m_PlayerControls_Mouse;
    private readonly InputAction m_PlayerControls_WasForwardsPressed;
    private readonly InputAction m_PlayerControls_WasBackwardsPressed;
    private readonly InputAction m_PlayerControls_WasRightPressed;
    private readonly InputAction m_PlayerControls_WasLeftPressed;
    public struct PlayerControlsActions
    {
        private @InputMaster m_Wrapper;
        public PlayerControlsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
        public InputAction @LookStraight => m_Wrapper.m_PlayerControls_LookStraight;
        public InputAction @Mouse => m_Wrapper.m_PlayerControls_Mouse;
        public InputAction @WasForwardsPressed => m_Wrapper.m_PlayerControls_WasForwardsPressed;
        public InputAction @WasBackwardsPressed => m_Wrapper.m_PlayerControls_WasBackwardsPressed;
        public InputAction @WasRightPressed => m_Wrapper.m_PlayerControls_WasRightPressed;
        public InputAction @WasLeftPressed => m_Wrapper.m_PlayerControls_WasLeftPressed;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @LookStraight.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLookStraight;
                @LookStraight.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLookStraight;
                @LookStraight.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnLookStraight;
                @Mouse.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMouse;
                @WasForwardsPressed.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasForwardsPressed;
                @WasForwardsPressed.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasForwardsPressed;
                @WasForwardsPressed.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasForwardsPressed;
                @WasBackwardsPressed.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasBackwardsPressed;
                @WasBackwardsPressed.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasBackwardsPressed;
                @WasBackwardsPressed.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasBackwardsPressed;
                @WasRightPressed.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasRightPressed;
                @WasRightPressed.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasRightPressed;
                @WasRightPressed.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasRightPressed;
                @WasLeftPressed.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasLeftPressed;
                @WasLeftPressed.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasLeftPressed;
                @WasLeftPressed.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnWasLeftPressed;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @LookStraight.started += instance.OnLookStraight;
                @LookStraight.performed += instance.OnLookStraight;
                @LookStraight.canceled += instance.OnLookStraight;
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
                @WasForwardsPressed.started += instance.OnWasForwardsPressed;
                @WasForwardsPressed.performed += instance.OnWasForwardsPressed;
                @WasForwardsPressed.canceled += instance.OnWasForwardsPressed;
                @WasBackwardsPressed.started += instance.OnWasBackwardsPressed;
                @WasBackwardsPressed.performed += instance.OnWasBackwardsPressed;
                @WasBackwardsPressed.canceled += instance.OnWasBackwardsPressed;
                @WasRightPressed.started += instance.OnWasRightPressed;
                @WasRightPressed.performed += instance.OnWasRightPressed;
                @WasRightPressed.canceled += instance.OnWasRightPressed;
                @WasLeftPressed.started += instance.OnWasLeftPressed;
                @WasLeftPressed.performed += instance.OnWasLeftPressed;
                @WasLeftPressed.canceled += instance.OnWasLeftPressed;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // GuiControls
    private readonly InputActionMap m_GuiControls;
    private IGuiControlsActions m_GuiControlsActionsCallbackInterface;
    private readonly InputAction m_GuiControls_ChangeVelToFloat;
    private readonly InputAction m_GuiControls_ChangeVelMode;
    private readonly InputAction m_GuiControls_PauseKey;
    private readonly InputAction m_GuiControls_ShowMovementMenu;
    private readonly InputAction m_GuiControls_ChangeKey;
    private readonly InputAction m_GuiControls_StopKey;
    private readonly InputAction m_GuiControls_MenuKey1;
    private readonly InputAction m_GuiControls_MenuKey2;
    private readonly InputAction m_GuiControls_MenuKey3;
    private readonly InputAction m_GuiControls_MenuKey4;
    private readonly InputAction m_GuiControls_MenuKey5;
    private readonly InputAction m_GuiControls_MenuKey6;
    private readonly InputAction m_GuiControls_MenuKey7;
    private readonly InputAction m_GuiControls_MenuKey8;
    private readonly InputAction m_GuiControls_MenuKey9;
    private readonly InputAction m_GuiControls_MenuKeyF1;
    private readonly InputAction m_GuiControls_MenuKeyF2;
    private readonly InputAction m_GuiControls_MenuKeyF3;
    private readonly InputAction m_GuiControls_MenuKeyF4;
    private readonly InputAction m_GuiControls_MenuKeyF5;
    private readonly InputAction m_GuiControls_MenuKeyF6;
    private readonly InputAction m_GuiControls_MenuKeyF7;
    private readonly InputAction m_GuiControls_MenuKeyF8;
    private readonly InputAction m_GuiControls_MenuKeyF9;
    public struct GuiControlsActions
    {
        private @InputMaster m_Wrapper;
        public GuiControlsActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChangeVelToFloat => m_Wrapper.m_GuiControls_ChangeVelToFloat;
        public InputAction @ChangeVelMode => m_Wrapper.m_GuiControls_ChangeVelMode;
        public InputAction @PauseKey => m_Wrapper.m_GuiControls_PauseKey;
        public InputAction @ShowMovementMenu => m_Wrapper.m_GuiControls_ShowMovementMenu;
        public InputAction @ChangeKey => m_Wrapper.m_GuiControls_ChangeKey;
        public InputAction @StopKey => m_Wrapper.m_GuiControls_StopKey;
        public InputAction @MenuKey1 => m_Wrapper.m_GuiControls_MenuKey1;
        public InputAction @MenuKey2 => m_Wrapper.m_GuiControls_MenuKey2;
        public InputAction @MenuKey3 => m_Wrapper.m_GuiControls_MenuKey3;
        public InputAction @MenuKey4 => m_Wrapper.m_GuiControls_MenuKey4;
        public InputAction @MenuKey5 => m_Wrapper.m_GuiControls_MenuKey5;
        public InputAction @MenuKey6 => m_Wrapper.m_GuiControls_MenuKey6;
        public InputAction @MenuKey7 => m_Wrapper.m_GuiControls_MenuKey7;
        public InputAction @MenuKey8 => m_Wrapper.m_GuiControls_MenuKey8;
        public InputAction @MenuKey9 => m_Wrapper.m_GuiControls_MenuKey9;
        public InputAction @MenuKeyF1 => m_Wrapper.m_GuiControls_MenuKeyF1;
        public InputAction @MenuKeyF2 => m_Wrapper.m_GuiControls_MenuKeyF2;
        public InputAction @MenuKeyF3 => m_Wrapper.m_GuiControls_MenuKeyF3;
        public InputAction @MenuKeyF4 => m_Wrapper.m_GuiControls_MenuKeyF4;
        public InputAction @MenuKeyF5 => m_Wrapper.m_GuiControls_MenuKeyF5;
        public InputAction @MenuKeyF6 => m_Wrapper.m_GuiControls_MenuKeyF6;
        public InputAction @MenuKeyF7 => m_Wrapper.m_GuiControls_MenuKeyF7;
        public InputAction @MenuKeyF8 => m_Wrapper.m_GuiControls_MenuKeyF8;
        public InputAction @MenuKeyF9 => m_Wrapper.m_GuiControls_MenuKeyF9;
        public InputActionMap Get() { return m_Wrapper.m_GuiControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GuiControlsActions set) { return set.Get(); }
        public void SetCallbacks(IGuiControlsActions instance)
        {
            if (m_Wrapper.m_GuiControlsActionsCallbackInterface != null)
            {
                @ChangeVelToFloat.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnChangeVelToFloat;
                @ChangeVelToFloat.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnChangeVelToFloat;
                @ChangeVelToFloat.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnChangeVelToFloat;
                @ChangeVelMode.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnChangeVelMode;
                @ChangeVelMode.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnChangeVelMode;
                @ChangeVelMode.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnChangeVelMode;
                @PauseKey.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnPauseKey;
                @PauseKey.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnPauseKey;
                @PauseKey.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnPauseKey;
                @ShowMovementMenu.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnShowMovementMenu;
                @ShowMovementMenu.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnShowMovementMenu;
                @ShowMovementMenu.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnShowMovementMenu;
                @ChangeKey.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnChangeKey;
                @ChangeKey.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnChangeKey;
                @ChangeKey.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnChangeKey;
                @StopKey.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnStopKey;
                @StopKey.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnStopKey;
                @StopKey.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnStopKey;
                @MenuKey1.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey1;
                @MenuKey1.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey1;
                @MenuKey1.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey1;
                @MenuKey2.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey2;
                @MenuKey2.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey2;
                @MenuKey2.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey2;
                @MenuKey3.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey3;
                @MenuKey3.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey3;
                @MenuKey3.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey3;
                @MenuKey4.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey4;
                @MenuKey4.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey4;
                @MenuKey4.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey4;
                @MenuKey5.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey5;
                @MenuKey5.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey5;
                @MenuKey5.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey5;
                @MenuKey6.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey6;
                @MenuKey6.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey6;
                @MenuKey6.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey6;
                @MenuKey7.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey7;
                @MenuKey7.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey7;
                @MenuKey7.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey7;
                @MenuKey8.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey8;
                @MenuKey8.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey8;
                @MenuKey8.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey8;
                @MenuKey9.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey9;
                @MenuKey9.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey9;
                @MenuKey9.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKey9;
                @MenuKeyF1.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF1;
                @MenuKeyF1.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF1;
                @MenuKeyF1.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF1;
                @MenuKeyF2.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF2;
                @MenuKeyF2.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF2;
                @MenuKeyF2.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF2;
                @MenuKeyF3.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF3;
                @MenuKeyF3.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF3;
                @MenuKeyF3.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF3;
                @MenuKeyF4.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF4;
                @MenuKeyF4.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF4;
                @MenuKeyF4.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF4;
                @MenuKeyF5.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF5;
                @MenuKeyF5.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF5;
                @MenuKeyF5.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF5;
                @MenuKeyF6.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF6;
                @MenuKeyF6.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF6;
                @MenuKeyF6.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF6;
                @MenuKeyF7.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF7;
                @MenuKeyF7.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF7;
                @MenuKeyF7.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF7;
                @MenuKeyF8.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF8;
                @MenuKeyF8.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF8;
                @MenuKeyF8.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF8;
                @MenuKeyF9.started -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF9;
                @MenuKeyF9.performed -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF9;
                @MenuKeyF9.canceled -= m_Wrapper.m_GuiControlsActionsCallbackInterface.OnMenuKeyF9;
            }
            m_Wrapper.m_GuiControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ChangeVelToFloat.started += instance.OnChangeVelToFloat;
                @ChangeVelToFloat.performed += instance.OnChangeVelToFloat;
                @ChangeVelToFloat.canceled += instance.OnChangeVelToFloat;
                @ChangeVelMode.started += instance.OnChangeVelMode;
                @ChangeVelMode.performed += instance.OnChangeVelMode;
                @ChangeVelMode.canceled += instance.OnChangeVelMode;
                @PauseKey.started += instance.OnPauseKey;
                @PauseKey.performed += instance.OnPauseKey;
                @PauseKey.canceled += instance.OnPauseKey;
                @ShowMovementMenu.started += instance.OnShowMovementMenu;
                @ShowMovementMenu.performed += instance.OnShowMovementMenu;
                @ShowMovementMenu.canceled += instance.OnShowMovementMenu;
                @ChangeKey.started += instance.OnChangeKey;
                @ChangeKey.performed += instance.OnChangeKey;
                @ChangeKey.canceled += instance.OnChangeKey;
                @StopKey.started += instance.OnStopKey;
                @StopKey.performed += instance.OnStopKey;
                @StopKey.canceled += instance.OnStopKey;
                @MenuKey1.started += instance.OnMenuKey1;
                @MenuKey1.performed += instance.OnMenuKey1;
                @MenuKey1.canceled += instance.OnMenuKey1;
                @MenuKey2.started += instance.OnMenuKey2;
                @MenuKey2.performed += instance.OnMenuKey2;
                @MenuKey2.canceled += instance.OnMenuKey2;
                @MenuKey3.started += instance.OnMenuKey3;
                @MenuKey3.performed += instance.OnMenuKey3;
                @MenuKey3.canceled += instance.OnMenuKey3;
                @MenuKey4.started += instance.OnMenuKey4;
                @MenuKey4.performed += instance.OnMenuKey4;
                @MenuKey4.canceled += instance.OnMenuKey4;
                @MenuKey5.started += instance.OnMenuKey5;
                @MenuKey5.performed += instance.OnMenuKey5;
                @MenuKey5.canceled += instance.OnMenuKey5;
                @MenuKey6.started += instance.OnMenuKey6;
                @MenuKey6.performed += instance.OnMenuKey6;
                @MenuKey6.canceled += instance.OnMenuKey6;
                @MenuKey7.started += instance.OnMenuKey7;
                @MenuKey7.performed += instance.OnMenuKey7;
                @MenuKey7.canceled += instance.OnMenuKey7;
                @MenuKey8.started += instance.OnMenuKey8;
                @MenuKey8.performed += instance.OnMenuKey8;
                @MenuKey8.canceled += instance.OnMenuKey8;
                @MenuKey9.started += instance.OnMenuKey9;
                @MenuKey9.performed += instance.OnMenuKey9;
                @MenuKey9.canceled += instance.OnMenuKey9;
                @MenuKeyF1.started += instance.OnMenuKeyF1;
                @MenuKeyF1.performed += instance.OnMenuKeyF1;
                @MenuKeyF1.canceled += instance.OnMenuKeyF1;
                @MenuKeyF2.started += instance.OnMenuKeyF2;
                @MenuKeyF2.performed += instance.OnMenuKeyF2;
                @MenuKeyF2.canceled += instance.OnMenuKeyF2;
                @MenuKeyF3.started += instance.OnMenuKeyF3;
                @MenuKeyF3.performed += instance.OnMenuKeyF3;
                @MenuKeyF3.canceled += instance.OnMenuKeyF3;
                @MenuKeyF4.started += instance.OnMenuKeyF4;
                @MenuKeyF4.performed += instance.OnMenuKeyF4;
                @MenuKeyF4.canceled += instance.OnMenuKeyF4;
                @MenuKeyF5.started += instance.OnMenuKeyF5;
                @MenuKeyF5.performed += instance.OnMenuKeyF5;
                @MenuKeyF5.canceled += instance.OnMenuKeyF5;
                @MenuKeyF6.started += instance.OnMenuKeyF6;
                @MenuKeyF6.performed += instance.OnMenuKeyF6;
                @MenuKeyF6.canceled += instance.OnMenuKeyF6;
                @MenuKeyF7.started += instance.OnMenuKeyF7;
                @MenuKeyF7.performed += instance.OnMenuKeyF7;
                @MenuKeyF7.canceled += instance.OnMenuKeyF7;
                @MenuKeyF8.started += instance.OnMenuKeyF8;
                @MenuKeyF8.performed += instance.OnMenuKeyF8;
                @MenuKeyF8.canceled += instance.OnMenuKeyF8;
                @MenuKeyF9.started += instance.OnMenuKeyF9;
                @MenuKeyF9.performed += instance.OnMenuKeyF9;
                @MenuKeyF9.canceled += instance.OnMenuKeyF9;
            }
        }
    }
    public GuiControlsActions @GuiControls => new GuiControlsActions(this);
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get
        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLookStraight(InputAction.CallbackContext context);
        void OnMouse(InputAction.CallbackContext context);
        void OnWasForwardsPressed(InputAction.CallbackContext context);
        void OnWasBackwardsPressed(InputAction.CallbackContext context);
        void OnWasRightPressed(InputAction.CallbackContext context);
        void OnWasLeftPressed(InputAction.CallbackContext context);
    }
    public interface IGuiControlsActions
    {
        void OnChangeVelToFloat(InputAction.CallbackContext context);
        void OnChangeVelMode(InputAction.CallbackContext context);
        void OnPauseKey(InputAction.CallbackContext context);
        void OnShowMovementMenu(InputAction.CallbackContext context);
        void OnChangeKey(InputAction.CallbackContext context);
        void OnStopKey(InputAction.CallbackContext context);
        void OnMenuKey1(InputAction.CallbackContext context);
        void OnMenuKey2(InputAction.CallbackContext context);
        void OnMenuKey3(InputAction.CallbackContext context);
        void OnMenuKey4(InputAction.CallbackContext context);
        void OnMenuKey5(InputAction.CallbackContext context);
        void OnMenuKey6(InputAction.CallbackContext context);
        void OnMenuKey7(InputAction.CallbackContext context);
        void OnMenuKey8(InputAction.CallbackContext context);
        void OnMenuKey9(InputAction.CallbackContext context);
        void OnMenuKeyF1(InputAction.CallbackContext context);
        void OnMenuKeyF2(InputAction.CallbackContext context);
        void OnMenuKeyF3(InputAction.CallbackContext context);
        void OnMenuKeyF4(InputAction.CallbackContext context);
        void OnMenuKeyF5(InputAction.CallbackContext context);
        void OnMenuKeyF6(InputAction.CallbackContext context);
        void OnMenuKeyF7(InputAction.CallbackContext context);
        void OnMenuKeyF8(InputAction.CallbackContext context);
        void OnMenuKeyF9(InputAction.CallbackContext context);
    }
}
