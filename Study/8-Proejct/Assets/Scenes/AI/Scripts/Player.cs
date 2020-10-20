namespace Scenes.AI
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.AI;
    using System.IO;
    using Scenes.Data.Save.Scripts;

    public class Player : MonoBehaviour, IDamagable
    {
        [SerializeField] private float speed;
        [SerializeField] private Camera cam;
        [SerializeField] private Stat stat;
        [SerializeField] private float noDamageTime = 0.5f;

        private NavMeshAgent _agent;
        private PlayerState _state;
        private Coroutine _damageRoutine;
        private bool _isdamagable;
        private MeshRenderer _renderer;

        public PlayerState State => _state;
        public float Hp => stat.Hp;
        public float MaxHp => stat.MaxHp;

        public float Mp => stat.MaxHp;
        public float MaxMp => stat.MaxMp;

        public Stat Stat => stat;

        public Camera Cam => cam;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _renderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            //transform.position = new Vector3(
            //    PlayerPrefs.GetFloat("player_position_x"),
            //    PlayerPrefs.GetFloat("player_position_y"),
            //    PlayerPrefs.GetFloat("player_position_z")
            //    );

            //transform.rotation = new Quaternion(
            //    PlayerPrefs.GetFloat("player_rotation_x"),
            //    PlayerPrefs.GetFloat("player_rotation_y"),
            //    PlayerPrefs.GetFloat("player_rotation_z"),
            //    PlayerPrefs.GetFloat("player_rotation_w")
            //    );

            //using (var streamReader = new StreamReader(Path.Combine(Application.persistentDataPath, "save_file.json")))
            //{
            //    var playerTransformSaveData = JsonUtility.FromJson<PlayerTrasmforSaveData>(streamReader.ReadToEnd());

            //    transform.position = playerTransformSaveData.playerPosition;
            //    transform.rotation = playerTransformSaveData.playerRotation;
            //}
        }

        private void OnEnable()
        {
            _isdamagable = true;
            stat.AddHp(stat.MaxHp);
        }

        private void OnDisable()
        {
            if (_damageRoutine != null) StopCoroutine(_damageRoutine);
        }

        private void Update()
        {
            var camTowardVector = (transform.position - cam.transform.position).normalized;
            var finalVector = (camTowardVector * Input.GetAxis("Vertical") +
                               cam.transform.right * Input.GetAxis("Horizontal")) * (speed * Time.deltaTime);
            var yRemovedVector = new Vector3(finalVector.x, 0, finalVector.z);
            _agent.Move(yRemovedVector);

            if (finalVector.magnitude >= Mathf.Epsilon)
                transform.rotation = Quaternion.LookRotation(yRemovedVector);
        }

        // Life Cycle Hook
        private void OnApplicationQuit()
        {
            //PlayerPrefs.SetFloat("player_position_x", transform.position.x);
            //PlayerPrefs.SetFloat("player_position_y", transform.position.y);
            //PlayerPrefs.SetFloat("player_position_z", transform.position.z);

            //PlayerPrefs.SetFloat("player_rotation_x", transform.rotation.x);
            //PlayerPrefs.SetFloat("player_rotation_y", transform.rotation.y);
            //PlayerPrefs.SetFloat("player_rotation_z", transform.rotation.z);
            //PlayerPrefs.SetFloat("player_rotation_w", transform.rotation.w);

            //var isTrue = false;
            //PlayerPrefs.SetInt("boolkey", isTrue ? 1 : 0);
            //isTrue = PlayerPrefs.GetInt("boolkey") == 1 ? true : false;

            // 운영체제마다 절대경로(root_dir)가 다르기 때문에 이를
            // 알아서 Seeking해주는 Application.persistentDataPath을 이용한다.
            // 운영체제마다 폴더 구분기호가 다르기 때문에
            // 이를 알아서 조합해주는 Path.Combine을 이용한다.
            // using을 통해 instancing 된 혹은 new 된 객체에 대해서
            // using문 안에서 알아서 close 혹은 Destroy가 된다.
            //using (var streamWriter = new StreamWriter(Path.Combine(Application.persistentDataPath, "save_file.json")))
            //{
            //    // JsonUtility.ToJson(): [Serializable]한 오브젝트에 한해서 Json으로 변경가능
            //    var jsonStr = JsonUtility.ToJson(new PlayerTrasmforSaveData
            //    {
            //        playerPosition = transform.position,
            //        playerRotation = transform.rotation
            //    });

            //    streamWriter.WriteLine(jsonStr);
            //}
        }

        public void Damage(float damageAmount)
        {
            if (!_isdamagable) return;
            _damageRoutine = StartCoroutine(DamageRoutine(damageAmount));
        }

        private IEnumerator DamageRoutine(float damageAmount)
        {
            stat.AddHp(-damageAmount);
            var material = _renderer.material;
            var defaultColor = material.color;

            material.color = new Color(1, 1, 1, 0.5f);
            _isdamagable = false;

            yield return new WaitForSeconds(noDamageTime);

            material.color = defaultColor;
            _isdamagable = true;
        }
    }
}