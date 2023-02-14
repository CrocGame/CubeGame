using UnityEngine.UI;
using UnityEngine;

public class Shop : MonoBehaviour
{
    
    [SerializeField] private PanelShopModel[] _modelPanels;
    [SerializeField] private PanelShopBackGround[] _modelBackGround;
    [SerializeField] private PanelShopCubeFloor[] _modelFloorBlock;
    [SerializeField] private PanelShopDiedZone[] _modelDiedZone;

    [SerializeField] private ModelView _modelView;
    [SerializeField] private ButtonAction _buttonAction;
    [SerializeField] private ViewBackGround _viewBackGround;
    [SerializeField] private GameObject _content;

    private void OnEnable()
    {

        Progress.Instance.PlayerInfo.StoryShopModel=CheckProgress(Progress.Instance.PlayerInfo.StoryShopModel, _modelPanels);
        Progress.Instance.PlayerInfo.StoryShopBackGround=CheckProgress(Progress.Instance.PlayerInfo.StoryShopBackGround, _modelBackGround);
        Progress.Instance.PlayerInfo.StoryShopfloorBlock=CheckProgress(Progress.Instance.PlayerInfo.StoryShopfloorBlock, _modelFloorBlock);
        Progress.Instance.PlayerInfo.StoryShopDiedZone=CheckProgress(Progress.Instance.PlayerInfo.StoryShopDiedZone, _modelDiedZone);


        _content.SetActive(true);

        GetActivModels();

    }
    private bool[] CheckProgress(bool[] progres, PanelShop[] shop)
    {
        if (progres.Length < shop.Length)
        {
            var mas = progres;
            progres = new bool[shop.Length];
            for (int i = 0; i < mas.Length; i++)
            {
                progres[i] = mas[i];
            }
            return progres;
        }
        return progres;
    }

    public void UpdateButtonModel(int Id)
    {
        _modelPanels[Id].SetUse();
        _modelView.UpdateModelView();
        _buttonAction.UpdateView();
    }
    public void UpdateButtonBackGround(int Id)
    {
        _modelBackGround[Id].SetUse();
        _viewBackGround.UpdateViewBackGround();
        _buttonAction.UpdateView();
    }
    public void UpdateButtonFloorBlock(int Id)
    {
        _modelFloorBlock[Id].SetUse();
        _buttonAction.UpdateView();
    }
    public void UpdateButtonDiedZone(int Id)
    {
        _modelDiedZone[Id].SetUse();
        _buttonAction.UpdateView();
    }
    public void GetActivModels()
    {
        Progress.Instance.SelectModel = _modelPanels[Progress.Instance.playerStat.NumActivModel].Model;
        Progress.Instance.SelectBackGrouns = _modelBackGround[Progress.Instance.playerStat.NumActivBackGround].SpriteBackGround;
        Progress.Instance.SelectFloorBlock = _modelFloorBlock[Progress.Instance.playerStat.NumActivFloorBlock].cubeFloor;
        Progress.Instance.SelectDiedZone = _modelDiedZone[Progress.Instance.playerStat.NumActivDiedZone].DiedZone;
    }

}
